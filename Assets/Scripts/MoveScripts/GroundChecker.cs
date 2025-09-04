using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _layerMask;

    private Collider2D[] _colliders = new Collider2D[10];
    private int _colliderCount;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public bool IsOnGround()
    {
        _colliderCount = Physics2D.OverlapCircleNonAlloc(_groundCheck.position, _groundCheckRadius,
           _colliders, _layerMask);

       return _isGrounded = _colliderCount > 0;
    }
}

