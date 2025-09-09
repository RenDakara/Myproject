using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
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
            _player.Heal(_healAmount);
        }
    }
}