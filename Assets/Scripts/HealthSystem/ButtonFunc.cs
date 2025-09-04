using UnityEngine;

public class ButtonFunc : MonoBehaviour
{
    private Health _health;
    private int _healAmount = 5;
    private int _damageAmount = 5;

    public void Heal()
    {
            _health.Heal(_healAmount);
    }

    public void TakeDamage()
    {
            _health.TakeDamage(_damageAmount);
    }
}
