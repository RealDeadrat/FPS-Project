using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.Camera;

public class PlMovMobile : MonoBehaviour
{

    private Rigidbody playerBody;

    private Vector3 inputMov;
    public float speed;

    public float jumpforce;
    public ForceMode forceType;

    public LayerMask groundLayers;

    public SphereCollider col;

    private bool didJump;
    Touch touch;

    Vector2 Mpos;
    Vector2 relMPos;

    public float cMovx;
    public float cMovy;

    public RawImage innerCircle;
    public RawImage outerCircle;

    CanvasScaler fuckYou;

    private int nextScene;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        fuckYou = GameObject.Find("User Interface").GetComponent<CanvasScaler>();


        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
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
                /*
                float logWidth = Mathf.Log(Screen.width / fuckYou.width, kLogBase);
                float logHeight = Mathf.Log(Screen.height / m_ReferenceResolution.y, kLogBase);
                float logWeightedAverage = Mathf.Lerp(logWidth, logHeight, m_MatchWidthOrHeight);
                scaleFactor = Mathf.Pow(kLogBase, logWeightedAverage);
                */

                Mpos = touch.position;
                outerCircle.rectTransform.anchoredPosition = new Vector2(Mpos.x / (Screen.width / fuckYou.referenceResolution.x), Mpos.y/(Screen.height/fuckYou.referenceResolution.y));
                Debug.Log(touch.position);
                Debug.Log(Mpos);
                innerCircle.enabled = true;
                outerCircle.enabled = true;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                relMPos = (touch.position - Mpos) * Time.deltaTime;
                //Vector2 relCPos = Vector2.ClampMagnitude(relMPos, 1.0f);
                innerCircle.rectTransform.anchoredPosition = new Vector2(relMPos.x, relMPos.y)*20f;
            }

            if (Mathf.Abs(relMPos.x) > .3f || Mathf.Abs(relMPos.y) > .3f)
            {
                inputMov = new Vector3(relMPos.x, 0, relMPos.y);
            }

            if(touch.phase == TouchPhase.Ended)
            {
                innerCircle.enabled = false;
                outerCircle.enabled = false;

                playerBody.velocity = new Vector3(0, playerBody.velocity.y,0);
                inputMov = Vector3.zero;
            }
        }

        if (didJump && IsGrounded())
        {

            playerBody.AddForce(Vector3.up * jumpforce, forceType);
            didJump = false;
        }
        /*
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(nextScene);
        }
        */
    }

    void FixedUpdate()
    {
       playerBody.AddRelativeForce(inputMov * speed);
     
    }

    public void Jump()
    {
        didJump = true;
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
    }
}

