using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2 : MonoBehaviour {
    Vector3 beforePosition, nowPosition;
    bool canMoreUp, canMoreDown;
    // Use this for initialization
    void Start()
    {
        canMoreUp = canMoreDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        nowPosition = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                Debug.Log(nowPosition.y - beforePosition.y + "");
                if (hit.transform.position.y > 2)
                    canMoreUp = false;
                else
                    canMoreUp = true;

                if (hit.transform.position.y < -1)
                    canMoreDown = false;
                else
                    canMoreDown = true;

                if ((nowPosition.y > beforePosition.y && canMoreUp) || (nowPosition.y < beforePosition.y && canMoreDown))
                    hit.transform.position += transform.up * (nowPosition.y - beforePosition.y) * Time.deltaTime;
            }
        }
        beforePosition = nowPosition;
    }
}
