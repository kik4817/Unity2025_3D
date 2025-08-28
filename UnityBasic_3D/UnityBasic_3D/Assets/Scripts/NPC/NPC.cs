using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    [SerializeField] NPCInfo npcInfo;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    private Vector2 currentTargetPos; // 언제 스탑을 해야하는가.

    private void Awake()
    {
        // NPC 클레스와 같은 오브젝트에 부착되어 있는 컴포넌트를 GetComponent로 가져와보세요.
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        // 컴포넌트에 데이터를 연결햇으면 실제 게임 데이터로 설정해주세요.

        spriteRenderer.sprite = npcInfo.Sprite;
        rigidbody2D.gravityScale = 0;
    }

    

    private void Start()
    {
        Patrol();
    }

    public void Patrol()
    {
        // 이동해라 MoceTargetPoint
        MoveTargetPoint();


        // 일정 시간 대기한다.
        WaitTime(3); // 3초 대기
    }

    private void Update()
    {
        // 목적지까지 이동한 후 멈춰라
        Stop();        
    }

    public void Stop()
    {

        //if()
        //{
        //    rigidbody2D.velocity = Vector2.zero;
        //}
    }

    public void WaitTime(float time)
    {

    }

    private void MoveTargetPoint()
    {
        // 속도의 랜덤값 구현
        float moveSpeed = Random.Range((float)npcInfo.MinSpeed, npcInfo.MaxSpeed);

        // 위치의 랜덤값 표현
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * npcInfo.PatrolRadius;

        //Debug.Log(randomPosition);

        currentTargetPos = randomPosition;

        // 이동 속도, 이동해야할 위치 현재 위치 (이동해야할 방향)
        // 방향 * 속도 = 이동

        rigidbody2D.velocity = (randomPosition * (Vector2)transform.position).normalized * moveSpeed;

        
    }
}
