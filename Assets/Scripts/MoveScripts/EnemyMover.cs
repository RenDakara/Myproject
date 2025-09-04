using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform[] _wayPoints; 
    [SerializeField] private Transform _player;

    private bool _isMovingRight = true;
    private Rigidbody2D _rigidbody;
    private int _firstPoint = 0;
    private int _lastPoint = 1;
    private Rotater _rotater;

    private void Awake()
    {
        _rotater = GetComponent<Rotater>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Patrol()
    {
        if (_isMovingRight)
        {
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
            _rotater.RotateCharacter(_speed);

            if (transform.position.x >= _wayPoints[_lastPoint].position.x)
            {
                _isMovingRight = false;              
            }
        }
        else
        {
            _rigidbody.velocity = new Vector2(-_speed, _rigidbody.velocity.y);
            _rotater.RotateCharacter(-_speed);

            if (transform.position.x <= _wayPoints[_firstPoint].position.x)
            {
                _isMovingRight = true;
            }
        }
    }
}

