using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityClass : MonoBehaviour
{
    private string abilityName;
    private float cooldown;
    private bool isUsed;
    private float timeTillUse;
    private string description;

    public AbilityClass(string abilityName, float cooldown, string description)
    {
        this.abilityName = abilityName;
        this.cooldown = cooldown;
        isUsed = false;
        timeTillUse = 0;
        this.description = description;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timeTillUse++;
    }
}
