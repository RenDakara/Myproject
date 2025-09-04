using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform _player;

    private Rigidbody2D _rigidbody;
    private Rotater _rotater;

    private void Awake()
    {
        _rotater = GetComponent<Rotater>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ChasePlayer()
    {
        Vector2 direction = (_player.position - transform.position).normalized;
        _rigidbody.velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);
        _rotater.RotateCharacter(direction.x * _speed);
    }
}

