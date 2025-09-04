using UnityEngine;

public class Rotater : MonoBehaviour
{
    public void RotateCharacter(float direction)
    {
        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }
}

