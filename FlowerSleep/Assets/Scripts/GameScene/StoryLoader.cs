using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StoryLoader : MonoBehaviour {
    //public static StoryLoader instance;
    public string storyPath = "Assets/Resources/Stories/"; //Set Story TextFile's Location
    int storyPhase; //Choosing What Story

    public ArrayList story = new ArrayList(); //Story Array
    public int storyIndex; //Story Array's Index

    public Text StoryText;
    public Text NameText;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("storyPhase")) //Initialization values
            storyPhase = PlayerPrefs.GetInt("storyPhase");
        else
            storyPhase = 0;
        storyIndex = 0;

        SetStory();
        SetText();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            SetText();
        }
	}
    public void Vibrate()
    {
        #if UNITY_ANDROID
        Handheld.Vibrate();
        #endif
    }
    public void SetStory() //Reading StoryText at TextFile's Location
    {
        FileStream fs = new FileStream(storyPath + storyPhase + ".txt", FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        string readStr;
        while ((readStr = sr.ReadLine()) != null)
        {
            story.Add(readStr);
        }
        sr.Close();
        fs.Close();
    }
    public void SetText()
    {
        string tmp = story[storyIndex++].ToString();
        if (tmp.Contains(":"))
        {
            string[] tmps = tmp.Split(':');
            NameText.text = tmps[0].Trim();
            StoryText.text = tmps[1].Trim();
        }
        else
        {
            NameText.text = "";
            StoryText.text = tmp;
        }
    }
}
