using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public string abilityName;
    public float cooldown;
    public string description;

    public Ability(string abilityName, float cooldown, string description)
    {
        this.abilityName = abilityName;
        this.cooldown = cooldown;
        this.description = description;
    }
}
