using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Rigidbody2D _rigidbody;
    private InputService _inputService;
    private bool _isRunning;
    private CharacterAnimator _playerRenderer;
    private Rotater _rotater;

    private void Awake()
    {
        _rotater = GetComponent<Rotater>();
        _playerRenderer = GetComponent<CharacterAnimator>();
        _inputService = GetComponent<InputService>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Run()
    {
        float horizontalInput = _inputService.GetHorizontalInput();

        if (horizontalInput != 0f)
        {
            Vector2 direction = new Vector2(horizontalInput, 0f).normalized;
            _rigidbody.velocity = direction * _speed;
            _isRunning = true;

            _rotater.RotateCharacter(horizontalInput);
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
            _isRunning = false;
        }

        _playerRenderer.PlayRunningAnimation(_isRunning);
    }
}