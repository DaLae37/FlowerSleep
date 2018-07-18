using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSceneManager : MonoBehaviour {
    private static MiniGameSceneManager instance;

    public GameObject[] miniGames = new GameObject[3];
    public GameObject main;

    void Start()
    {
        instance = this;
    }

    public MiniGameSceneManager getInstance()
    {
        return instance;
    }

    public void MiniGame1()
    {
        main.SetActive(false);
        miniGames[0].SetActive(true);
    }

    public void MiniGame2()
    {
        main.SetActive(false);
        miniGames[1].SetActive(true);
    }

    public void MiniGame3()
    {
        main.SetActive(false);
        miniGames[2].SetActive(true);
    }
}