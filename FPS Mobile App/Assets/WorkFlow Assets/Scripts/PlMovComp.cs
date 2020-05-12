using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlMovComp : NetworkBehaviour
{

    private Rigidbody playerBody;

    private Vector3 inputMov;
    public float speed = 50f;

    public float jumpforce;
    public ForceMode forceType;

    public LayerMask groundLayers;

    public SphereCollider col;

    private int nextScene;
    
    
 


    // Start is called before the first frame update
    void Start()
    {
      //  if(hasAuthority == false)
       // {
      //      return;
       // }
        Camera.main.transform.SetParent(transform);
        playerBody = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
       //if(hasAuthority == false)
      // {
        //    return;
       // }
        inputMov = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Jump") == 1 && IsGrounded())
        {
            playerBody.AddForce(Vector3.up * jumpforce, forceType);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){

            GameObject.Find("Ability").GetComponent<AbilityScript>().UseAbility();
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            GetComponent<Teleport>().Update();

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            GetComponent<ForceField>().DoAbility();

        }
        


        /*
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene(nextScene);
        }
        */
    }

    void FixedUpdate()
    {
       //if (hasAuthority == false)
        //{
          // return;
     //  }
        playerBody.AddRelativeForce(inputMov * speed);
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}
   
