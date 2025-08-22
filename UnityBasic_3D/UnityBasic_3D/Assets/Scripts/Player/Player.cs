using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 기능을 구현하는 것이 목표입니다.
// 전투와 관련된 요소를 정의합니다.

// 직열화 (Serialized) : 우리가 직접 정의한 클래스 정보를 유니티에서 읽어올 수 없기 때문에 유니티 인스팩터창에서 노출할 수 없다
// 유니티가 우리가 정의한 정보를 읽을 수 있도록 조치를 취하면 된다.

public class Player : Battle
{
    //public BattleEntity battleEntity;

    ////public int playerHP;
    ////public int playerATK;
    ////public int playerDEF;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    //battleEntity = new BattleEntity(playerHP, playerATK, playerDEF);

    //    Debug.Log($"HP : {battleEntity.HP}, ATK : {battleEntity.ATK}, DEF : {battleEntity.DEF}");
    //}

    public override void Attack(Battle other)
    {
        if (!battleManager.playerTurn) return;

        other.TakeDamge(this);

        battleManager.TurnChange();
    }

    public override void AttackSP(Battle other)
    {
        if (!battleManager.playerTurn) return;

        base.AttackSP(other);

        battleManager.TurnChange(); // player턴을 넘겨라
    }


    //public override void Attack()
    //{
    //    if (!battleManager.playerTurn) return;

    //    base.Attack();

    //    battleManager.TurnChange(); // player턴을 넘겨라
    //}

    public override void Defend(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.Defend(amount);

        battleManager.TurnChange();
    }


    public override void Recover(int HpAmount)//, int SpAmount)
    {
        if (!battleManager.playerTurn) return;

        base.Recover(HpAmount);//, SpAmount);

        battleManager.TurnChange();
    }
    public override void HpUp(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.HpUp(amount);

        battleManager.TurnChange();
    }
    public override void SpUp(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.SpUp(amount);

        battleManager.TurnChange();
    }
    public override void AttackUp(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.AttackUp(amount);

        battleManager.TurnChange();
    }
    public override void ShieldUP(int amount)
    {
        if (!battleManager.playerTurn) return;

        base.ShieldUP(amount);

        battleManager.TurnChange();
    }
}
