using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ProfileSceneManager : MonoBehaviour {
    public Text inputName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveName()
    {
        PlayerPrefs.SetString("name", inputName.text);
        SceneManager.LoadScene("MainScene");
    }
}
