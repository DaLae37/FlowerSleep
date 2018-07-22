using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameSceneManager : MonoBehaviour {
    private static MiniGameSceneManager instance;

    public GameObject[] miniGames = new GameObject[3];
    public GameObject main;

    void Start()
    {
        instance = this;
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
    public MiniGameSceneManager getInstance()
    {
        return instance;
    }

    public void MiniGame1()
    {
        main.SetActive(false);
        miniGames[0].SetActive(true);
    }

    public void MiniGame2()
    {
        main.SetActive(false);
        miniGames[1].SetActive(true);
    }

    public void MiniGame3()
    {
        main.SetActive(false);
        miniGames[2].SetActive(true);
    }
}