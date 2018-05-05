using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneManager : MonoBehaviour {
    private int save_file1, save_file2, save_file3;
	// Use this for initialization
	void Start () {
        save_file1 = save_file2 = save_file3 = -1;
        if (PlayerPrefs.HasKey("save_file1"))
        {
            save_file1 = PlayerPrefs.GetInt("save_file1");
        }
        if (PlayerPrefs.HasKey("save_file2"))
        {
            save_file2 = PlayerPrefs.GetInt("save_file2");
        }
        if (PlayerPrefs.HasKey("save_file3"))
        {
            save_file3 = PlayerPrefs.GetInt("save_file3");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveFile1()
    {
        if(save_file1 != -1)
        {
            PlayerPrefs.SetInt("storyPhase", save_file1);
            SceneManager.LoadScene("GameScene");
        }
    }
    public void SaveFile2()
    {
        if(save_file2 != -1)
        {
            PlayerPrefs.SetInt("storyPhase", save_file2);
            SceneManager.LoadScene("GameScene");
        }
    }
    public void SaveFile3() 
    {
        if(save_file3 != -1)
        {
            PlayerPrefs.SetInt("storyPhase", save_file3);
            SceneManager.LoadScene("GameScene");
        }
    }
}
