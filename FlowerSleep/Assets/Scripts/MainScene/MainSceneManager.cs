using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainSceneManager : MonoBehaviour {
    void Start()
    {
        if(!PlayerPrefs.HasKey("name"))
        {
            ProfileScene();
        }
    }
    public void GameScene()
    {
        PlayerPrefs.SetInt("storyPhase", 0);
        SceneManager.LoadScene("GameScene");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("LoadScene");
    }
    public void SettingScene()
    {
        SceneManager.LoadScene("SettingScene");
    }
    public void GalleryScene()
    {
        SceneManager.LoadScene("GalleryScene");
    }
    public void ProfileScene()
    {
        SceneManager.LoadScene("ProfileScene");
    }
    public void StatusScene()
    {
        SceneManager.LoadScene("StatusScene");
    }
    public void MiniGameScene()
    {
        SceneManager.LoadScene("MiniGameScene");
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
