using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class LifestealCollider : MonoBehaviour
{
    private CircleCollider2D _drainCollider;
    private LayerMask _enemyLayer;

    private List<Health> _enemiesInRange = new List<Health>();

    public IReadOnlyList<Health> EnemiesInRange => _enemiesInRange;

    private void Awake()
    {
        _drainCollider = GetComponent<CircleCollider2D>();
        _drainCollider.isTrigger = true;
        _drainCollider.enabled = false;
    }

    public void SetRadius(float radius)
    {
        _drainCollider.radius = radius;
    }

    public void SetEnemyLayer(LayerMask layer)
    {
        _enemyLayer = layer;
        gameObject.layer = LayerMask.NameToLayer("Ability");
    }

    public void SetActive(bool active)
    {
        _drainCollider.enabled = active;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_enemyLayer.value & (1 << collision.gameObject.layer)) == 0)
            return;

        if (collision.TryGetComponent(out Enemy enemy))
        {
            if (enemy.TryGetComponent(out Health enemyHealth))
            {
                if (!_enemiesInRange.Contains(enemyHealth))
                    _enemiesInRange.Add(enemyHealth);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            if (enemy.TryGetComponent(out Health enemyHealth))
            {
                _enemiesInRange.Remove(enemyHealth);
            }
        }
    }
}