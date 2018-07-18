using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingSceneManager : MonoBehaviour {
    public static LoadingSceneManager instance;
    private bool isEyesOpenFinish = false;
    private bool isButtonEffectFinish = false;
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setIsEyesOpenFinish(bool isEyesOpenFinish)
    {
        this.isEyesOpenFinish = isEyesOpenFinish;
    }

    public void setIsButtonEffectFinish(bool isButtonEffectFinish)
    {
        this.isButtonEffectFinish = isButtonEffectFinish;
    }

    public void MainScene()
    {
        if(isEyesOpenFinish && isButtonEffectFinish)
            SceneManager.LoadScene("MainScene");
    }
}
