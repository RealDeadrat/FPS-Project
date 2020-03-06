using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLookMobile : MonoBehaviour
{
    public float mouseSensitivity = 1f;

    public Transform playerTransform;

    Touch touch;

    Vector2 pos;
    Vector2 relPos;

   float xRotation = 0f;

    public RawImage innerCircle;
    public RawImage outerCircle;

    CanvasScaler fuckYou;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        fuckYou = GameObject.Find("User Interface").GetComponent<CanvasScaler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).position.x > Screen.width / 2)
                {
                    touch = Input.GetTouch(i);
                }
            }

            if (touch.phase == TouchPhase.Began)
            {
                pos = touch.position;

                outerCircle.rectTransform.anchoredPosition = new Vector2(pos.x / (Screen.width / fuckYou.referenceResolution.x), pos.y / (Screen.height / fuckYou.referenceResolution.y));

                innerCircle.enabled = true;
                outerCircle.enabled = true;
            }
            if (touch.phase == TouchPhase.Moved && pos.x > Screen.width/2)
            {
                relPos = (touch.position - pos)*Time.deltaTime;

                innerCircle.rectTransform.anchoredPosition = new Vector2(relPos.x, relPos.y) * 20f;
            }
            else
            {
                relPos = Vector2.zero;

            }
            if (touch.phase == TouchPhase.Ended)
            {

                innerCircle.enabled = false;
                outerCircle.enabled = false;
            }
            

            if(Mathf.Abs(relPos.x) > .3f || Mathf.Abs(relPos.y) > .3f)
            {
                xRotation -= relPos.y;

                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                playerTransform.Rotate(Vector3.up * relPos.x);
            }
              
             
        }
    }
}
