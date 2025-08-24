using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �θ��� �Լ��� �����ͼ� ����ϴ� ����� �н��մϴ�.
// �θ��� �Լ��� �ٽ� �����Ѵ�(������) override

//[System.Serializable]

namespace BattleExample
{
    public class Monster : Battle
    {
        [SerializeField] Animator animator;

        public override void Attack(Battle other)
        {
            if (battleManager.playerTurn) return;

            animator.SetTrigger("Attack");

            // Battle������Ʈ�� ������ �ִ� ��밡.TakeDamage(this.BattleEntity);
            other.TakeDamge(this);
        }

        public override void AttackSP(Battle other)
        {
            if (battleManager.playerTurn) return;

            animator.SetTrigger("Attack");

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

        public override void Recover()
        {
            if (battleManager.playerTurn) return;

            base.Recover();
        }

        public override void TakeDamge(Battle other)
        {
            animator.SetTrigger("Hit");
            base.TakeDamge(other);
        }
    } 
}
