using UnityEngine;

public class EnemyHitDetector : MonoBehaviour
{
    private string _playerFeet = "PlayerFeet";
    private string _enemyHead = "EnemyHead";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int playerFeetLayer = LayerMask.NameToLayer(_playerFeet);
        int enemyHeadLayer = LayerMask.NameToLayer(_enemyHead);

        if (gameObject.layer == enemyHeadLayer && collision.gameObject.layer == playerFeetLayer)
        {
            Enemy enemy = GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                enemy.Die();
            }
        }
    }
}
