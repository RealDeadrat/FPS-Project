using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    // https://www.youtube.com/watch?v=a19LDuHUFwc

    public GameObject shield;
    private bool shieldEnabled;
  


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    public void DoAbility()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            shieldEnabled = !shieldEnabled;
        }

        if (shieldEnabled)
        {
            shield.SetActive(true);
        }

        else
        {
            shield.SetActive(false);
        }
    }

    
}
