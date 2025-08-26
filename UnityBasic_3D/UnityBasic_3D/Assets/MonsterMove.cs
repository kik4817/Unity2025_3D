using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    //2D 월드에서 랜덤한 위치로 이동하는 코드를 작성해줘
    //이동 속도는 얼마인가
    //이동 하는 방식은 무엇인가? rigidbody2d를 이용한 물리엔진 방식입니다.
    //서로 충동했을 때는 어떤 일인가?

    // Inspector에서 설정할 수 있는 변수
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;    
    [SerializeField] private Rigidbody2D rigid;
    private Vector2 targetVector;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        SetPositionToCenter();

        rigid.velocity = targetVector.normalized * moveSpeed;
    }

    private Vector2 SetPositionToCenter()
    {
        return Vector2.zero - (Vector2)transform.position;
    }
}
