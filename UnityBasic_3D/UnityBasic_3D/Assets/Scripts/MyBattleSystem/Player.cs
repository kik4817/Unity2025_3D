using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Battle
{
    // 충돌체크를 위한 변수
    [SerializeField] AttackChecker attackChecker;

    // 1. 왜 변수를 추가해야 하는가?
    // 2. 변수에 데이터를 초기화할 것인가. <1> 유니티 인스팩터 <2> 코드를 사용해서
   
    [SerializeField] Animator animator;    

    private void Start()
    {
        attackChecker = GetComponent<AttackChecker>();
    }

    // 애니메이터를 실행하기 위한 컴포넌트 Animator(멤버 변수)
    public override void Attack(Battle other)
    {
        // 공격을 하면서 애니메이션을 실행시키겠다

        // 공격을 하면서 UI Text를 출력시키겠다

        // 충돌 이벤트를 구현해보겠다.
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
