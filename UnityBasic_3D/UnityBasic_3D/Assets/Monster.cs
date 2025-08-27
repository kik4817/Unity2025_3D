using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    // 오늘의 목표 : 코드로 게임에 등장하는 오브젝트를 조립한다.
    // 컴퓨터와 대화를(C#) 해서 몬스터가 필요한 정보를 전달.
    // 이동 속도(MonsterMove), Sprite정보

    public class Monster : MonoBehaviour
    {
        // 몬스터가 움직이는 코드를 생성한다.
        // 움직이는 속도가 필요하다.
        // 몬스터가 어떻게 생겼는지 Sprite
        // 위치, 회전, 크기        

        public MonsterInfo monsterInfo;
             

        private void Start()
        {
            MonsterConstructor();
        }

        [ContextMenu("몬스터 생성")]
        public void MonsterConstructor()
        {
            GameObject instance = new GameObject();
            instance.transform.localScale = Vector3.one * monsterInfo.size;
            
            SpriteRenderer sr = instance.AddComponent<SpriteRenderer>();
            sr.sprite = monsterInfo.sprite;
            //sr.color = monsterInfo.color;

            MonsterMove monsterMove = instance.AddComponent<MonsterMove>();
            monsterMove.moveSpeed = monsterInfo.moveSpeed;
            
            Rigidbody2D rigid = instance.AddComponent<Rigidbody2D>();
            rigid.gravityScale = 0;

            // 몬스터 충돌
            CapsuleCollider2D cc2d = instance.AddComponent<CapsuleCollider2D>();
            cc2d.offset = new Vector2(0, -0.28f);
            cc2d.size = new Vector2(2.66f, 3.10f);

            instance.name = monsterInfo.monsterName;
        }
    }
}
