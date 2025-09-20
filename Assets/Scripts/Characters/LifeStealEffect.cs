using System.Collections.Generic;

public static class LifestealEffect
{
    public static void ApplyEffect(Player player, IReadOnlyList<Health> enemies, float healAmount)
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            var enemyHealth = enemies[i];
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(healAmount);
                player.Heal(healAmount);
            }
        }
    }
}