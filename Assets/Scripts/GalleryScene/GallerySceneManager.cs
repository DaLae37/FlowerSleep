using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GallerySceneManager : MonoBehaviour {
    public Image image;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.Android)
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

    public void OpenPanel()
    {
        image.gameObject.SetActive(true);
    }

 
}
