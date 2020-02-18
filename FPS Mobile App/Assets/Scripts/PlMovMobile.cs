using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlMovMobile : MonoBehaviour
{

    private Rigidbody playerBody;

    private Vector3 inputMov;
    public float speed = 5f;

    public float jumpforce;
    public ForceMode forceType;

    public LayerMask groundLayers;

    public SphereCollider col;

    Vector2 pos;
    Vector2 relPos;
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
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                pos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved && pos.x < Screen.width / 2)
            {
                relPos = (touch.position - pos) * Time.deltaTime;
            }
            else
            {
                relPos = Vector2.zero;
            }

            if (Mathf.Abs(relPos.x) > .3f || Mathf.Abs(relPos.y) > .3f)
            {
                inputMov = new Vector3(relPos.x, 0, relPos.y);
            }
        }

        if (Input.GetAxisRaw("Jump") == 1 && IsGrounded())
        {

            playerBody.AddForce(Vector3.up * jumpforce, forceType);
        }


    }

    void FixedUpdate()
    {
        playerBody.AddForce(inputMov * speed);
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}

