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

    public Sprite[]CharacterImage = new Sprite[2];
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

        SetStory(storyPhase.ToString() + ".txt");
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
        string path = pathForDocumentsFile("Resources/Stories/" + fileName);
        if (File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string readStr = null;
            while ((readStr = sr.ReadLine()) != null)
            {
                story.Add(readStr);
            }
            sr.Close();
            file.Close();
        }
    }

    public void SetText()
    {
        string tmp = story[storyIndex++].ToString();
        if (tmp.Contains(":"))
        {
            string[] tmps = tmp.Split(':');
            if (PlayerPrefs.HasKey("name"))
            {
                switch (tmps[0].Trim())
                {
                    case "여주":
                        NameText.text = PlayerPrefs.GetString("name");
                        SetCharacter(1);
                        break;
                    default :
                        NameText.text = tmps[0].Trim();
                        SetCharacter(0);
                        break;
                }
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

    public string pathForDocumentsFile(string filename)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string path = Application.dataPath.Substring(0, Application.dataPath.Length - 5);
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(Path.Combine(path, "Documents"), filename);
        }

        else if (Application.platform == RuntimePlatform.Android)
        {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }

        else
        {
            string path = Application.dataPath;
            return Path.Combine(path, filename);
        }
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
