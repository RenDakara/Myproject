using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        if (_target != null)
        {
            transform.position = _target.position + _offset;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
