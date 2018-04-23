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

    private bool isChainingDone;
    private string chainingString;
    private int chainingStringIndex;
    // Use this for initialization
    void Start () {
        if (PlayerPrefs.HasKey("storyPhase")) //Initialization values
            storyPhase = PlayerPrefs.GetInt("storyPhase");
        else
            storyPhase = 0;
        storyIndex = 0;
        isChainingDone = false;
        chainingStringIndex = 0;

        SetStory();
        SetText();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (isChainingDone)
            {
                isChainingDone = false;
                chainingStringIndex = 0;
                SetText();
            }
            else
            {
                StopCoroutine("ChainingText");
                isChainingDone = true;
                StoryText.text = chainingString;
            }
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
            chainingString = tmps[1].Trim();
        }
        else
        {
            NameText.text = "";
            chainingString = tmp;
        }
        StartCoroutine("ChainingText");
    }

    IEnumerator ChainingText()
    {
        do
        {
            StoryText.text = chainingString.Substring(0, chainingStringIndex++);
            yield return new WaitForSeconds(0.1f);
        } while (chainingStringIndex != chainingString.Length);
        isChainingDone = true;
    }
}
