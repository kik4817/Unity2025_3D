using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. 동전을 먹었을 때 작동하라
public class CoinSpawner : MonoBehaviour
{
    
    [SerializeField] int SpawnCount = 2;

    public GameObject CoinPrefab;

    private void OnEnable()
    {
        Bus<IGetCoinEvent>.OnEvent += HandleGetCoin;
    }

    private void OnDisable()
    {
        Bus<IGetCoinEvent>.OnEvent -= HandleGetCoin;
    }

    private void HandleGetCoin(IGetCoinEvent evt)
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            Vector2 randomwSpawnPos = UnityEngine.Random.insideUnitCircle * 10;

            // 게임에 플레이어가 코인을 획득한 경우에 코인을 생성하고 싶습니다.
            Instantiate(CoinPrefab, transform.position + (Vector3)randomwSpawnPos, Quaternion.identity);
        }
    }


}
