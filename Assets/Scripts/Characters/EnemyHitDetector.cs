using UnityEngine;

public class EnemyHitDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int playerFeetLayer = LayerMask.NameToLayer("PlayerFeet");
        int enemyHeadLayer = LayerMask.NameToLayer("EnemyHead");

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
