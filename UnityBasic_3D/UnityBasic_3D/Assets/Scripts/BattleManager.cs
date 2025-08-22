using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Turn
    int turnValue;

    public bool playerTurn = true;

    public void TurnChange()
    {
        playerTurn = !playerTurn;
        
        EnemyTurn();
    }

    private void EnemyTurn()
    {
        EnemyAI();

        playerTurn = true;
    }

    // Enemy 행동한다.

    public Battle Player;
    public Battle Enemy;

    public void EnemyAI()
    {
        // 랜덤으로 0~2 숫자를 받아온다.
        int RandomValue = UnityEngine.Random.Range(0, 4);
        //Debug.Log($"랜덤 값의 정확성 확인 {RandomValue}");

        switch(RandomValue)
        {
            case 0:
                Enemy.Attack(Player);
                break;
            case 1:
                Enemy.AttackSP(Player);
                break;
            case 2:
                Enemy.Defend(5);
                break;
            case 3:
                Enemy.Recover(10);//, 5);
                break;
            default:
                break;
        }
    }
}
