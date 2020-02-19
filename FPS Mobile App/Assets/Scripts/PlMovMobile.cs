﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlMovMobile : MonoBehaviour
{

    private Rigidbody playerBody;

    private Vector3 inputMov;
    public float speed;

    public float jumpforce;
    public ForceMode forceType;

    public LayerMask groundLayers;

    public SphereCollider col;

    Touch touch;

    Vector2 Mpos;
    Vector2 relMPos;

    public float cMovx;
    public float cMovy;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for(int i=0; i<Input.touchCount;i++)
            {
                if(Input.GetTouch(i).position.x < Screen.width / 2)
                {
                    touch = Input.GetTouch(i);
                }
            }
            

            if (touch.phase == TouchPhase.Began)
            {
                Mpos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                relMPos = (touch.position - Mpos) * Time.deltaTime;
            }

            if (Mathf.Abs(relMPos.x) > .3f || Mathf.Abs(relMPos.y) > .3f)
            {
                inputMov = new Vector3(relMPos.x, 0, relMPos.y);
            }

            if(touch.phase == TouchPhase.Ended)
            {
                playerBody.velocity = new Vector3(0, playerBody.velocity.y,0);
                inputMov = Vector3.zero;
            }
        }

        if (Input.GetAxisRaw("Jump") == 1 && IsGrounded())
        {

            playerBody.AddForce(Vector3.up * jumpforce, forceType);
        }


    }

    void FixedUpdate()
    {
       playerBody.AddRelativeForce(inputMov * speed);
     
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}

