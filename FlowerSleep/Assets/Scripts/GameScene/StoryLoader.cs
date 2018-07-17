using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StoryLoader : MonoBehaviour
{
    //public static StoryLoader instance;
    int storyPhase; //Choosing What Story

    public ArrayList story = new ArrayList(); //Story Array
    public int storyIndex; //Story Array's Index

    public Text StoryText;
    public Text NameText;

    private bool isChainingDone;
    private string chainingString;
    private int chainingStringIndex;

    public Sprite[]CharacterImage = new Sprite[5];
    public Image CharacterPos;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("storyPhase")) //Initialization values
            storyPhase = PlayerPrefs.GetInt("storyPhase");
        else
            storyPhase = 0;
        storyIndex = 0;
        isChainingDone = false;
        chainingStringIndex = 0;

        SetStory(storyPhase.ToString() + "");
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
#if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
#endif
    }
    
    public void SetStory(string fileName) //Reading StoryText at TextFile's Location
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Stories/" + fileName);
        StringReader reader = new StringReader(textAsset.text);

        string readStr = null;
        while ((readStr = reader.ReadLine()) != null)
        {
            story.Add(readStr);
        }
        reader.Close();
    }

    public void SetText()
    {
        string tmp = story[storyIndex++].ToString();
        if (tmp.Contains(":"))
        {
            string[] tmps = tmp.Split(':');
            NameText.text = tmps[0].Trim();
            switch (tmps[0].Trim())
            {
                case "여주":
                    if (PlayerPrefs.HasKey("name"))
                        NameText.text = PlayerPrefs.GetString("name");
                    SetCharacter(1);
                    break;
                case "아버지":
                    SetCharacter(2);
                    break;
                case "어머니":
                    SetCharacter(3);
                    break;
                case "부모님":
                    SetCharacter(4);
                    break;
                default:
                    NameText.text = tmps[0].Trim();
                    SetCharacter(0);
                    break;
            }

            chainingString = tmps[1].Trim();
        }
        else
        {
            NameText.text = "";
            chainingString = tmp;
            SetCharacter(0);
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
    
    void SetCharacter(params int []who)
    {
        if(who.Length == 1)
        {
            CharacterPos.GetComponent<Image>().sprite = CharacterImage[who[0]];
        }
        else if(who.Length == 2)
        {

        }
    }
}
