using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부모의 함수를 가져와서 사용하는 방법을 학습합니다.
// 부모의 함수를 다시 정의한다(재정의) override

[System.Serializable]
public class Monster : Battle
{
    public override void Attack(Battle other)
    {
        if (battleManager.playerTurn) return;

        // Battle컴포넌트를 가지고 있는 상대가.TakeDamage(this.BattleEntity);
        other.TakeDamge(this);
    }

    public override void AttackSP(Battle other)
    {
        if (battleManager.playerTurn) return;

        base.AttackSP(other);
    }



    //public override void Attack()
    //{
    //    // battleManager에서 player턴이라면 실행하지 마세요.
    //    if (battleManager.playerTurn) return;


    //    base.Attack(); // 몬스터의 공격 로직을 실행 후.

    //    // battleManager에서 턴을 종료합니다. - 몬스터는 할 필요가 없다.       
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
