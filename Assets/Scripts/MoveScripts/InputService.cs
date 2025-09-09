using UnityEngine;

public class InputService : MonoBehaviour
{
    private float _horizontalInput;
    private bool _jumpInput;
    private bool _abilityInput;

    private void Update()
    {
        _horizontalInput = Input.GetAxis(InputAxis.Horizontal);
        _jumpInput = Input.GetButtonDown(InputAxis.Jump);
        _abilityInput = Input.GetKeyDown(KeyCode.E);
    }

    public float GetHorizontalInput()
    {
        return _horizontalInput;
    }

    public bool GetJumpInput()
    {
        return _jumpInput;
    }

    public bool GetLifestealInput()
    {
        return _abilityInput;
    }
}