using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _AttackerRange = 1f;

    private CharacterAnimator _enemyRenderer;

    private void Awake()
    {
        _enemyRenderer = GetComponent<CharacterAnimator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= _AttackerRange)
            {
                player.TakeDamage(_damage);
                _enemyRenderer.PlayRunningAnimation(false);
                _enemyRenderer.PlayAttackAnimation(true);
            }
        }
    }
}