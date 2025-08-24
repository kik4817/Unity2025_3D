using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Battle
{
    // �浹üũ�� ���� ����
    [SerializeField] AttackChecker attackChecker;

    // 1. �� ������ �߰��ؾ� �ϴ°�?
    // 2. ������ �����͸� �ʱ�ȭ�� ���ΰ�. <1> ����Ƽ �ν����� <2> �ڵ带 ����ؼ�
   
    [SerializeField] Animator animator;    

    private void Start()
    {
        attackChecker = GetComponent<AttackChecker>();
    }

    // �ִϸ����͸� �����ϱ� ���� ������Ʈ Animator(��� ����)
    public override void Attack(Battle other)
    {
        // ������ �ϸ鼭 �ִϸ��̼��� �����Ű�ڴ�

        // ������ �ϸ鼭 UI Text�� ��½�Ű�ڴ�

        // �浹 �̺�Ʈ�� �����غ��ڴ�.
        animator.SetTrigger("Attack");

        attackChecker.gameObject.SetActive(true);

    }

    public override void Recover()
    {
        animator.SetTrigger("Recover");

        base.Recover();
    }

    public override void ShieldUP(int amount)
    {
        animator.SetTrigger("ShildUp");

        base.ShieldUP(amount);
    }

    public override void TakeDamge(Battle other)
    {
        animator.SetTrigger("Hit");
        base.TakeDamge(other);
    }
}
