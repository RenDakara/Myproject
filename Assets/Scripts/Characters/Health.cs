using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentAmount = 100f;
    [SerializeField] private Player _player;

    public event Action HPChanged;

    private float _max = 100f;
    private float _min = 0f;
    private float _current = 100;

    public float Current => _current;
    public float Max => _max;

    private void Awake()
    {
        _current = _max;
        _player = GetComponent<Player>();
    }

    public void Heal(float amount)
    {
        if (amount >= 0)
        {
            _current += amount;
            _current = Mathf.Clamp(_current, _min, _max);
            HPChanged?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            _current -= damage;
            _current = Mathf.Clamp(_current, _min, _max);
            HPChanged?.Invoke();
        }
    }
}
