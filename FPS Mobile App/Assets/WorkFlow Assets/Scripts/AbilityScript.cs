using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScript : MonoBehaviour
{

    Rigidbody abilityBody;
    public Rigidbody playerBody;
    bool isUsed = false;
    bool inUse = false;
    Ability gravityPool;
    public Transform playerTransform;

    private float useTime;
    private ForceMode forceType = ForceMode.Impulse;

    private Vector3 suckDirection;
    private float suckConstant;
    private float suckMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        abilityBody = GetComponent<Rigidbody>();
        playerBody = GameObject.Find("Player").GetComponent<Rigidbody>();
        gravityPool = new Ability("Gravity Pool", 5f, "Creates a blackhole, which explodes after a few seconds");
        useTime = gravityPool.cooldown;
    }

    void Update()
    {

        suckDirection = playerTransform.position - transform.position;
        suckConstant = suckDirection.x * suckDirection.x + suckDirection.y * suckDirection.y + suckDirection.z * suckDirection.z;
        suckMagnitude = Mathf.Clamp((-1000/suckConstant),-10000,10000);
        if (isUsed)
        {
            useTime = Time.time + gravityPool.cooldown;
        }
        if(inUse && Time.time >= useTime)
        {
            inUse = false;
            useTime = gravityPool.cooldown;
        }
        
    }
    
    void FixedUpdate()
    {
        if(!inUse)
        {
            transform.position = playerTransform.position + new Vector3(0,3,0);
            transform.rotation = playerTransform.rotation;
           // transform.Rotate(Vector3.up*playerTransform.localRotation.y);
            abilityBody.useGravity = false;
            abilityBody.isKinematic = false;
        }
        if (isUsed)
        {
            abilityBody.AddRelativeForce(0, 3f, 10, forceType);
            isUsed = false;
            abilityBody.useGravity = true;
        }
        if(inUse && abilityBody.isKinematic)
        {
            playerBody.AddForce(suckMagnitude*suckDirection);
        }
    }

    public void UseAbility()
    {
        if (!inUse)
        {
            isUsed = true;
            inUse = true;

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        abilityBody.isKinematic = true;
    }
}
