using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private float baseValue;
    [SerializeField] private List<StatModifier> modifiers; // 아이템 창착 여부, 버프 유무, 레벨증가

    public float GetValue()
    {
        return GetFinalValue();
    }

    public void AddModifier(float value, string source)
    {
        StatModifier modToAadd = new StatModifier(value, source);
        modifiers.Add(modToAadd);
    }

    public void RemoveModifier(string source) // buff, equip unequip
    {
        modifiers.RemoveAll(mod => mod.source == source);

        //foreach(var mod in modifiers)
        //{
        //    if(mod.source == source)
        //    {
        //        modifiers.Remove(mod);
        //    }
        //}
    }

    private float GetFinalValue()
    {
        float finalValue = baseValue;

        // 아이템, 버프, 레벨업
        foreach(var mod in modifiers)
        {
            finalValue += mod.value;
        }

        return finalValue;
    }
}

[System.Serializable]
public class StatModifier
{
    public float value;
    public string source;

    public StatModifier(float value, string source)
    {
        this.value = value;
        this.source = source;
    }
}
