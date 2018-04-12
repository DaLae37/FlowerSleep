using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainSceneManager : MonoBehaviour {
    public void GameScene()
    {
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
