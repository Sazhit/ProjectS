using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public virtual bool CanUse(PlayerController player) { return true; }

    public virtual void Use(PlayerController player) { }
}


