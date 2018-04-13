using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingSceneManager : MonoBehaviour {
    public Image BGMBar;
    public Image SEBar;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
