using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_stats : MonoBehaviour
{
    [SerializeField] private Entity_statsData statData;
    public Entity_statsData StatData {  get; set; }

    public float GetMaxHealth()
    {
        float baseHP = statData.MaxHealth.GetValue();
        float bonusHP = statData.Vitality.GetValue() * 5;

        return baseHP + bonusHP;
    }

    private void Awake()
    {
        StatData = (Entity_statsData)statData.Clone();
        StatData.Vitality.AddModifier(5, "Item"); // 아이템으로 인해 체력스탯이 5가 상승했다.
    }

    //public float GetPhysicalAttack() { }
}
