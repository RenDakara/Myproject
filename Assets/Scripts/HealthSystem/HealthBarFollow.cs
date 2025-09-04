using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if (_target != null)
        transform.position = _target.position + _offset;

        if (_target == null)
            gameObject.SetActive(false);
            
    }
}
