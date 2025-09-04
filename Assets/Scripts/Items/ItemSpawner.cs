using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private HealthPack _healthPack;
    [SerializeField] private List<Transform> _coinSpawnPosition;
    [SerializeField] private List<Transform> _healthSpawnPosition;

    private void Start()
    {
        SpawnCoin();
        SpawnHealthPack();
    }

    private void HandleItemCollected(Item item)
    {
        Destroy(item.gameObject);
    }

    private void SpawnCoin()
    {
        foreach (Transform spawnPoint in _coinSpawnPosition)
        {
            Coin coin = Instantiate(_coin, spawnPoint.position, spawnPoint.rotation);

            coin.OnItemCollected += HandleItemCollected;
        }
    }

    private void SpawnHealthPack()
    {
        foreach (Transform spawnPoint in _healthSpawnPosition)
        {
            HealthPack healthPack = Instantiate(_healthPack, spawnPoint.position, spawnPoint.rotation);

            healthPack.OnItemCollected += HandleItemCollected;
        }
    }
}

