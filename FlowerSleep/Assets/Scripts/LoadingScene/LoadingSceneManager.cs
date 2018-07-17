using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingSceneManager : MonoBehaviour {
    public static LoadingSceneManager instance;
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
