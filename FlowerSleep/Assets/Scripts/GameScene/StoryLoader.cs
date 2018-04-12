using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StoryLoader : MonoBehaviour {
    public string storyPath = "Assets/Resources/Stories/"; //Set Story TextFile's Location
    int storyPhase; //Choosing What Story
    public static ArrayList story = new ArrayList(); //
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("storyPhase"))
        {
            storyPhase = PlayerPrefs.GetInt("storyPhase");
        }
        else
        {
            storyPhase = 0;
        }
        FileStream fs = new FileStream(storyPath + storyPhase + ".txt", FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        string readStr;
        while((readStr = sr.ReadLine())!=null){
            story.Add(readStr);
            Debug.Log(readStr);
        }
        sr.Close();
        fs.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
