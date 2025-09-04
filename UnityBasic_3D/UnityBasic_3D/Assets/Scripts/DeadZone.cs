using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.GameOver(); // 시점 호출
        }

        // GameOverUI호출
        // 게임 시작을 정지해라
        // 버튼 재시작, 게임 종료
    }
}
