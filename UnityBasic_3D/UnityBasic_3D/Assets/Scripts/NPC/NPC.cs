using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public enum CollisionEvent
{
    Friendly, UnFrinedly, UnDefined
}

public class NPC : MonoBehaviour
{
    [SerializeField] public NPCInfo npcInfo;
    [SerializeField] CollisionEvent collisionEvent = CollisionEvent.UnDefined;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    [SerializeField] private Vector2 currentTargetPos; // 언제 스탑을 해야하는가.
    [SerializeField] private bool isMovig; // 목적지 도착 후에 한번만 위치를 재설정하기 위함
    //[SerializeField] private bool test1; // true이면 정찰, false면 추적
    Transform playerPos;

    // 정찰, 추적

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
        SetRandomPosition();
    }


    private void Update()
    {
        // 언제 정찰? 현재 플레이어와이ㅡ 거리에 따라서 정찰을 할지 추적을 할지 정한다.
        // test1 대신에 Vector2.Distance 함수를 사용해서 코드를 활용해보세요
        if (IsPatrol())
            // 목적지까지 이동한 후 멈춰라
            Patrol();

        // 언제 추적?
        else
            Chase();
    }

    // 현재 상태를 체크해주는 함수
    bool IsPatrol()
    {        
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < npcInfo.patrolDistance)
        {            
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Patrol()
    {
        // 이동해라 MoceTargetPoint
        MoveTargetPoint();


        // 일정 시간 대기한다.
        //WaitTime(3); // 3초 대기
    }

    public void Chase()
    {
        // Player를 어떻게 받아올 것인가. 게임오브젝트의 이름이 player, tag가 player오브젝트를 전달해준다.
        
        SetPosition(playerPos.position);
        MoveTargetPoint();
    }

    private void MoveTargetPoint()
    {
        // 속도의 랜덤값 구현
        float moveSpeed = Random.Range((float)npcInfo.MinSpeed, npcInfo.MaxSpeed);


        //Debug.Log(randomPosition);        

        // 이동 속도, 이동해야할 위치 현재 위치 (이동해야할 방향)
        // 방향 * 속도 = 이동
        // 두 백터 위치 값과 속도를 사용해서 =>코드를 구현하세요. 이동해야할 방향 * 속도

        // 목적지까지 도착했으면 멈춰라
        // Vector Distance함수
        if(Vector2.Distance(transform.position, currentTargetPos) < npcInfo.stopDistance) // 대상과의 멈추기 위한 거리 StopDistance
        {
            rigidbody2D.velocity = Vector2.zero;
            isMovig = true;

            // 잠시 기다리는 시간 부여
            // 이벤트 처리. StopEvent
            //if (isMovig)
            //{
            //    StartCoroutine(SetRandomPositionCoroutine());
            //    //Invoke(nameof(SetRandomPosition), 1f);
            //}

            if (IsPatrol())
                SetRandomPosition();
           
        }
        else // 그렇지 않으면 이동하라
        {            
            rigidbody2D.velocity = (currentTargetPos - (Vector2)transform.position).normalized * moveSpeed;
        }


                
    }

    private void SetRandomPosition()
    {
        // 위치의 랜덤값 표현
        currentTargetPos = (Vector2)transform.position + Random.insideUnitCircle * npcInfo.PatrolRadius;
    }

    public void SetPosition(Vector2 position)
    {
        currentTargetPos = position;
    }

    private IEnumerator SetRandomPositionCoroutine()
    {
        isMovig = false;
        yield return new WaitForSeconds(1f);
        SetRandomPosition();
    }

    // 기즈모를 그리는 특수한 함수
    private void OnDrawGizmos()
    {
        //DrawChaseCircle();
    }

    private void OnDrawGizmosSelected()
    {
        DrawChaseCircle();
    }

    private void DrawChaseCircle()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, npcInfo.patrolDistance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // NPC가 플레이어와 충돌했을 때 이벤트를 방생시켜라.

            if(collisionEvent == CollisionEvent.Friendly)
            {
                Bus<ICollisionWithPlayerEvent>.Raise(new ICollisionWithPlayerEvent(this)); 
                gameObject.SetActive(false);
                Time.timeScale = 0.1f;
                //Bus<IFriendlyCollisionEvent>.Raise();
            }
            else if(collisionEvent == CollisionEvent.UnFrinedly)
            {
                //Bus<IUnFriendlyCollisionEvent>.Raise();
            }
            else
            {
                Debug.LogWarning("정의되지 않은 이벤트가 발생했습니다.");
            }

            //Bus<IScoreUpdateEvent>.Raise(new IScoreUpdateEvent(10)); // 이벤트를 발생시켜라 명령
            //ScoreManager.Instance.Score += 10; // 직접 ScoreManager 데이터를 수정하는 코드
        }
    }
}
