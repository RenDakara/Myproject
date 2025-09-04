using UnityEngine;

public class InputService : MonoBehaviour
{
    private float _horizontalInput;
    private bool _jumpInput;

    private void Update()
    {
        _horizontalInput = Input.GetAxis(InputAxis.Horizontal);
        _jumpInput = Input.GetButtonDown(InputAxis.Jump);
    }

    public float GetHorizontalInput()
    {
        return _horizontalInput;
    }

    public bool GetJumpInput()
    {
        return _jumpInput;
    }
}