using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGame3 : MonoBehaviour {
    public Image water;

    bool isTouch;
    // Use this for initialization
    void Start()
    {
        water.fillAmount = 0;
        isTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isTouch = true;
    }

    IEnumerator FillWater()
    {
        float fillAmount = 10;
        do
        {
            yield return new WaitForSeconds(0.001f);
        } while (fillAmount > 0);
    }

    IEnumerator SetBucket()
    {
        do
        {
            yield return new WaitForSeconds(1f);
        } while (isTouch);
    }
}
