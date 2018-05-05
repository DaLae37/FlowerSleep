using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingSceneManager : MonoBehaviour {
    public Slider BGM_Slider;
    public Slider SE_Slider;

    public Toggle BGM_Mute;
    public Toggle SE_Mute;

    private bool isBGM_Mute;
    private bool isSE_Mute;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("bgm") && PlayerPrefs.HasKey("se"))
        {
            BGM_Slider.value = PlayerPrefs.GetFloat("bgm"); //Getting before BGM Slider's value(0~1)
            SE_Slider.value = PlayerPrefs.GetFloat("se"); //Same to above

            isBGM_Mute = (PlayerPrefs.GetInt("bgm_mute") == 1) ? true : false; //Setting on mute botton If before setting on
            isSE_Mute = (PlayerPrefs.GetInt("se_mute") == 1) ? true : false; //Same to above
        }
        else //Resetting if don't have before setting
        {
            BGM_Slider.value = 1;
            SE_Slider.value = 1;

            isBGM_Mute = false;
            isSE_Mute = false;
        }
        BGM_Mute.isOn = isBGM_Mute;
        SE_Mute.isOn = isSE_Mute;
	}
	
	// Update is called once per frame
	void Update () {
			
	}

    public void MainScene()
    {
		PlayerPrefs.SetFloat("bgm",BGM_Slider.value); //Save BGM Slider's value
		PlayerPrefs.SetFloat("se",SE_Slider.value); //Save SE Slider's value

        PlayerPrefs.SetInt("bgm_mute", (isBGM_Mute) ? 1 : 0); //Save BGM is mute
        PlayerPrefs.SetInt("se_mute", (isSE_Mute) ? 1 : 0); //Save SE is mute

        SceneManager.LoadScene("MainScene");
    }

    public void BGMSliderChanged() //Invoke this function When BGM Slider is changed
    {
        if (isBGM_Mute)
            isBGM_Mute = false;
    }

    public void SESliderChanged() //Invoke this function When SE Slider is changed
    {
        if (isSE_Mute)
            isSE_Mute = false;
    }

    public void BGMMuteChanged() //Invoke this function When BGM Mute is clicked
    {
        isBGM_Mute = !isBGM_Mute;
    }

    public void SEMuteChanged() //Invoke this function When SE Mute is clicked
    {
        isSE_Mute = !isSE_Mute;
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MainScene");
    }
}
