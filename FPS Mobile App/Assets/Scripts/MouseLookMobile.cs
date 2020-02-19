using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookMobile : MonoBehaviour
{
    public float mouseSensitivity = 1f;

    public Transform playerTransform;

    Touch touch;

    Vector2 pos;
    Vector2 relPos;

   float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
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
            }
            if (touch.phase == TouchPhase.Moved && pos.x > Screen.width/2)
            {
                relPos = (touch.position - pos)*Time.deltaTime;
            }
            else
            {
                relPos = Vector2.zero;
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
