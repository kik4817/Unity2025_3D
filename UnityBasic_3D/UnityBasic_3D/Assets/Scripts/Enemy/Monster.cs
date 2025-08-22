using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �θ��� �Լ��� �����ͼ� ����ϴ� ����� �н��մϴ�.
// �θ��� �Լ��� �ٽ� �����Ѵ�(������) override

[System.Serializable]
public class Monster : Battle
{
    public override void Attack(Battle other)
    {
        if (battleManager.playerTurn) return;

        // Battle������Ʈ�� ������ �ִ� ��밡.TakeDamage(this.BattleEntity);
        other.TakeDamge(this);
    }

    public override void AttackSP(Battle other)
    {
        if (battleManager.playerTurn) return;

        base.AttackSP(other);
    }



    //public override void Attack()
    //{
    //    // battleManager���� player���̶�� �������� ������.
    //    if (battleManager.playerTurn) return;


    //    base.Attack(); // ������ ���� ������ ���� ��.

    //    // battleManager���� ���� �����մϴ�. - ���ʹ� �� �ʿ䰡 ����.       
    //}

    public override void Defend(int amount)
    {
        if (battleManager.playerTurn) return;

        base.Defend(amount);
    }

    public override void Recover(int HpAmount)//, int SpAmount)
    {
        if (battleManager.playerTurn) return;

        base.Recover(HpAmount);//, SpAmount);
    }

    //public override void ShieldUP(int amount)
    //{
    //    if (battleManager.playerTurn) return; 

    //    base.ShieldUP(amount);
    //}

    
}
