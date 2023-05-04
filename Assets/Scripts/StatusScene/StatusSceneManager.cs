using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusSceneManager : MonoBehaviour {
    public Image[] bars = new Image[4];
    public Text nameText;

    private static StatusSceneManager instance;

    private int aheadPoint;
    private int barsIndex;

	// Use this for initialization
	void Start () {
        instance = this;
        SetBars(75, 0);
        nameText.text = PlayerPrefs.GetString("name");
	}

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                MainScene();
            }
        }
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public StatusSceneManager getInstance()
    {
        return instance;
    }

    public void SetBars(int aheadPoint, int barsIndex)
    {
        this.aheadPoint = aheadPoint;
        this.barsIndex = barsIndex;

        StartCoroutine("ChangeBar");
    }

    IEnumerator ChangeBar()
    {
        float fillPerSecond = (aheadPoint - (bars[barsIndex].fillAmount * 100)) / 2000f;
        float timer = 0f;
        do
        {
            bars[barsIndex].fillAmount += fillPerSecond;
            yield return new WaitForSeconds(0.001f);
            timer += 0.001f;
        } while (timer < 1f);
    }
}