using UnityEngine;

[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(HealthUIControl))]
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

        _health.ValueChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        if (_health != null)
            _health.ValueChanged -= OnHealthChanged;
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

    private void OnHealthChanged()
    {
        if (_health.Current <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}