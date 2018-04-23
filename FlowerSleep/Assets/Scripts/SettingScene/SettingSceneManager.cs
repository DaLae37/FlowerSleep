using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingSceneManager : MonoBehaviour {
    public Slider BGMBar;
    public Slider SEBar;
    public Toggle BGMMute;
    public Toggle SEMute;
    
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("bgm") && PlayerPrefs.HasKey("se")){
				BGMBar.value = PlayerPrefs.GetFloat("bgm");
				SEBar.value = PlayerPrefs.GetFloat("se");
		}
		else{
				BGMBar.value = 0;
				SEBar.value = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
			
	}

    public void MainScene()
    {
		PlayerPrefs.SetFloat("bgm",BGMBar.value);
		PlayerPrefs.SetFloat("se",SEBar.value);
        SceneManager.LoadScene("MainScene");
    }
}
