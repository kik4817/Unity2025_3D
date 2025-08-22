using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� ����� �����ϴ� ���� ��ǥ�Դϴ�.
// ������ ���õ� ��Ҹ� �����մϴ�.

// ����ȭ (Serialized) : �츮�� ���� ������ Ŭ���� ������ ����Ƽ���� �о�� �� ���� ������ ����Ƽ �ν�����â���� ������ �� ����
// ����Ƽ�� �츮�� ������ ������ ���� �� �ֵ��� ��ġ�� ���ϸ� �ȴ�.

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

        battleManager.TurnChange(); // player���� �Ѱܶ�
    }


    //public override void Attack()
    //{
    //    if (!battleManager.playerTurn) return;

    //    base.Attack();

    //    battleManager.TurnChange(); // player���� �Ѱܶ�
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
