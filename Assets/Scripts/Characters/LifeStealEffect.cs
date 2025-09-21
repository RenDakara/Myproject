using UnityEngine;

public class LifestealEffect : MonoBehaviour
{
    public void ApplyEffect(Player player, Health enemy, float healAmount)
    {
        if (enemy != null)
        {
            enemy.TakeDamage(healAmount);
            player.Heal(healAmount);
        }
    }
}