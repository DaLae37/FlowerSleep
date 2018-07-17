using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EyesOpenEffect : MonoBehaviour {
    public Image Eyes;
	// Use this for initialization
	void Start () {
        StartCoroutine("OpenEyes");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator OpenEyes()
    {
        do
        {
            Eyes.color = new Color(Eyes.color.r, Eyes.color.g, Eyes.color.b, Eyes.color.a - 0.01f);
            yield return new WaitForSeconds(0.015f);
        } while (Eyes.color.a > 0);
        LoadingSceneManager.instance.MainScene();
    }
}
