using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 주위를 돌아다니도록 기능 가진 AI
// 최소 속도, 최대 속도 변수로 정의
// Sprite
// 이름

[CreateAssetMenu(fileName = "Default NPC Name", menuName = "ScriptableObject/NPCData", order = 101)]
public class NPCInfo : ScriptableObject
{
    public int MinSpeed;
    public int MaxSpeed;
    public int PatrolRadius;
    public Sprite Sprite;
    public string NpcName;
    //public Rigidbody2D Rigidbody;
    //public Collider2D Collider;
    //public SpriteRenderer SpriteRenderer;
}
