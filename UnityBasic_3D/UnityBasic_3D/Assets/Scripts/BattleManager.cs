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
        //EnemyTurn();
    }

    // Enemy �ൿ�Ѵ�.

    public Battle Enemy;

    public void EnemyAI()
    {
        // �������� 0~2 ���ڸ� �޾ƿ´�.
        int RandomValue = UnityEngine.Random.Range(0, 3);

        switch(RandomValue)
        {
            case 0:
                // Enemy.Attack();
                break;
            case 1:
                Enemy.Recover(10);
                break;
            case 2:
                Enemy.ShieldUP(5);
                break;
            default:
                break;
        }
    }
}
