using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _detectionRange = 5f;

    private CharacterAnimator _enemyRenderer;
    private EnemyMover _enemyMover;
    private EnemyChaser _enemyChaser;
    private Health _health;

    public Health Health { get; private set; }

    private void Awake()
    {
        _enemyChaser = GetComponent<EnemyChaser>();
        _enemyRenderer = GetComponent<CharacterAnimator>();
        _enemyMover = GetComponent<EnemyMover>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            _enemyChaser.ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    private void Patrol()
    {
        _enemyRenderer.PlayAttackAnimation(false);
        _enemyRenderer.PlayRunningAnimation(true);
        _enemyMover.Patrol();
    }

    private bool IsPlayerInRange()
    {
        return (_playerPosition.position - transform.position).sqrMagnitude <= _detectionRange * _detectionRange;
    }
}

