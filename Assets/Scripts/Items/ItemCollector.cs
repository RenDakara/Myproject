using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private float _healAmount = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.Collect();
        }
       else if (collision.TryGetComponent(out HealthPack healthPack))
        {
            healthPack.Collect();
            if (TryGetComponent(out Player player))
            {
                player.Heal(_healAmount);
            }
        }
    }
}
