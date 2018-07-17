using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSceneManager : MonoBehaviour {
    public GameObject[] games = new GameObject[3];
    // Use this for initialization
    void Start()
    {
        int len = games.Length, select = PlayerPrefs.GetInt("MiniGame");
        for (int i = 0; i < games.Length; i++)
        {
            if (i == select)
                games[i].SetActive(true);
            else
                games[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}