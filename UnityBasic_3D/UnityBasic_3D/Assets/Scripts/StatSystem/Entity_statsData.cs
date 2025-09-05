using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Custom/Stat System/EntityStats")]
public class Entity_statsData : ScriptableObject, ICloneable
{
    public Stat MaxHealth;
    public Stat Strength;
    public Stat Dexerity;
    public Stat Intelligence;
    public Stat Vitality;

    public object Clone()
    {
        return Instantiate(this);
    }
}
