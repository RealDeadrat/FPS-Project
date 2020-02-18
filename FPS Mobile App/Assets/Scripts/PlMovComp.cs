using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlMovComp : MonoBehaviour
{

    private Rigidbody playerBody;

    private Vector3 inputMov;
    public float speed = 50f;

    public float jumpforce;
    public ForceMode forceType;

    public LayerMask groundLayers;

    public SphereCollider col;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        inputMov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

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
   
