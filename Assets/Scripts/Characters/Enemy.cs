using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CharacterAnimator _enemyRenderer;
    private EnemyMover _enemyMover;
    private EnemyChaser _enemyChaser;
    private Health _health;

    private bool _isChasing = false;

    private void Awake()
    {
        _enemyChaser = GetComponent<EnemyChaser>();
        _enemyRenderer = GetComponent<CharacterAnimator>();
        _enemyMover = GetComponent<EnemyMover>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_isChasing)
        {
            _enemyRenderer.PlayRunningAnimation(true);
            _enemyRenderer.PlayAttackAnimation(false);
        }
        else
        {
            Patrol();
        }
    }

    public void StartChasing()
    {
        if (!_isChasing)
        {
            _isChasing = true;
        }
    }

    public void StopChasing()
    {
        if (_isChasing)
        {
            _isChasing = false;
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
}

