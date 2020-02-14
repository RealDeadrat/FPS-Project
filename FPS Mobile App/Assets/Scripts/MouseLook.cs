using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1f;

    public Transform playerBody;

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
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                pos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                relPos = (touch.position - pos)*Time.deltaTime;
                Debug.Log(relPos.x);
                Debug.Log(relPos.y);
            }

              xRotation -= relPos.y;

              xRotation = Mathf.Clamp(xRotation, -90f, 90f);

              transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
              playerBody.Rotate(Vector3.up * relPos.x);
             
        }
    }
}
