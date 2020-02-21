using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScript : MonoBehaviour
{

    Rigidbody AbilityBody;

    // Start is called before the first frame update
    void Start()
    {
        AbilityBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
