using UnityEngine;

public class ButtonFunc : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    private Health _health;
    private int _healAmount = 5;
    private int _damageAmount = 5;

    private void Awake()
    {
            _health = _playerObject.GetComponent<Health>();
    }

    public void Heal()
    {
            _health.Heal(_healAmount);
    }

    public void TakeDamage()
    {
            _health.TakeDamage(_damageAmount);
    }
}
