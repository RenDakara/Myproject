using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMover _movement;
    private Jumper _jumper;
    private Health _health;
    private HealthUIControl _healthUIControl;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _movement = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
        _healthUIControl = GetComponent<HealthUIControl>();
    }

    private void Update()
    {
        _movement.Run();
        _healthUIControl.ShowHealth();
    }

    private void FixedUpdate()
    {
        _jumper.Jump();
    }

    public void TakeDamage(float damage)
    {
      _health.TakeDamage(damage);
    }

    public void Heal(float amount)
    {
        _health.Heal(amount);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
