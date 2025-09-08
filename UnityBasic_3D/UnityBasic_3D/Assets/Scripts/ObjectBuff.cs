using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Buff
{
    public StatType type = StatType.UnDefined;
    public float Value = 5.0f;
}

public class ObjectBuff : MonoBehaviour
{
    Entity_stats statsToMod;
    SpriteRenderer sr;

    [Header("Buff Detail")]
    //[SerializeField] StatType type = StatType.UnDefined;
    //[SerializeField] private float buffValue = 5.0f;
    [SerializeField] Buff[] buffs;
    [SerializeField] private float buffTime = 5.0f;
    [SerializeField] private string buffName;

    // Tag가 Player인 객체와 충동했을 때 => OnT 또는 OnC 트리거 체크

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // collision으로 부터 Component를 Get해서 statsToMod저장하세요

            statsToMod = collision.GetComponent<Entity_stats>();
            StartCoroutine(BuffCo());
        }
    }
    IEnumerator BuffCo()
    {
        // if Entity_stats가 있을때만 넣어라.

        // SpriteRenderer 변수를 추가한 후 sr.color 안보이게 성정하는 코드를 작성해보세요
        sr.color = Color.clear;

        //foreach(var buff in buffs)
        foreach (var buff in buffs)
        {
            statsToMod.GetStatByType(buff.type).AddModifier(buff.Value, buffName);
        }
        //statsToMod.StatData.Vitality.AddModifier(buffValue, buffName); // 아이템으로 인해 체력스탯이 5가 상승했다.
        //Debug.Log($"플레이어의 현제 체력 스탯 : {statToMod.StatData.Vitality.GetValue()}"); // 잘되면 아래코드로 수정
        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());


        // ?? 초 Delay후에 증가되었던 임시 스탯을 없에고, 이 오브젝트를 파괴하라.     
        yield return new WaitForSeconds(buffTime);

        foreach (var buff in buffs)
        {           
            statsToMod.GetStatByType(buff.type).RemoveModifier(buffName);
        }
        //statsToMod.StatData.Vitality.RemoveModifier(buffName); // Item경로로 부터 얻은 스탯을 제거하라.
        Bus<IStatUpdateEvent>.Raise(new IStatUpdateEvent());        
        Destroy(gameObject);
    }


}
