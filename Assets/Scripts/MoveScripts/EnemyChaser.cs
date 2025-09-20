using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _detectionRange = 5f;
    [SerializeField] private Transform _player;

    private Rigidbody2D _rigidbody;
    private Rotater _rotater;
    private Enemy _enemy;

    private void Awake()
    {
        _rotater = GetComponent<Rotater>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            _enemy.StartChasing();
            ChasePlayer();
        }
        else
        {
            _enemy.StopChasing();
        }
    }

    private bool IsPlayerInRange()
    {
        return (_player.position - transform.position).sqrMagnitude <= _detectionRange * _detectionRange;
    }

    public void ChasePlayer()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rigidbody.velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);
        _rotater.RotateCharacter(direction.x * _speed);
    }
}