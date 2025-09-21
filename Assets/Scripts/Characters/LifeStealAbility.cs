using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifestealAbility : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private LifestealEffect _lifestealEffect;
    [SerializeField] private float _healthPerSec = 5f;
    [SerializeField] private float _abilityRadius = 10f;
    [SerializeField] private float _abilityTime = 6f;
    [SerializeField] private float _abilityCooldown = 4f;

    private bool _abilityOnCooldown = false;
    private bool _abilityActive = false;
    private Coroutine _abilityCoroutine;

    private LifestealCollider _lifestealCollider;
    private Player _player;
    private InputService _inputService;

    public delegate void AbilityVisualStateChanged(bool active);
    public event AbilityVisualStateChanged OnVisualStateChanged;

    private void Awake()
    {
        _lifestealEffect = GetComponent<LifestealEffect>();
        _lifestealCollider = GetComponentInChildren<LifestealCollider>();
        _player = GetComponent<Player>();
        _inputService = GetComponent<InputService>();

        _lifestealCollider.SetRadius(_abilityRadius);
        _lifestealCollider.SetEnemyLayer(_enemyLayer);
        _lifestealCollider.SetActive(false);
    }

    private void Update()
    {
        if (_inputService.GetLifestealInput() && !_abilityOnCooldown && !_abilityActive)
        {
            _abilityCoroutine = StartCoroutine(ToggleAbility());
        }
    }

    private IEnumerator ToggleAbility()
    {
        _abilityActive = true;
        _abilityOnCooldown = false;
        _lifestealCollider.SetActive(true);
        OnVisualStateChanged?.Invoke(true);

        float elapsed = 0f;
        while (elapsed < _abilityTime)
        {
            float healAmount = _healthPerSec * Time.deltaTime;
            var enemies = _lifestealCollider.EnemiesInRange;

            if (enemies.Count > 0)
            {
                Health nearestEnemy = FindNearestEnemy(enemies);
                if (nearestEnemy != null)
                {
                    _lifestealEffect.ApplyEffect(_player, nearestEnemy, healAmount);
                }
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        _abilityActive = false;
        _lifestealCollider.SetActive(false);
        OnVisualStateChanged?.Invoke(false);

        _abilityOnCooldown = true;
        yield return new WaitForSeconds(_abilityCooldown);
        _abilityOnCooldown = false;
    }

    private Health FindNearestEnemy(IReadOnlyList<Health> enemies)
    {
        Health nearest = null;
        float minDistanceSqr = float.MaxValue;
        Vector3 currentPosition = transform.position;

        foreach (var enemy in enemies)
        {
            if (enemy == null) continue; 
            float distSqr = (enemy.transform.position - currentPosition).sqrMagnitude;
            if (distSqr < minDistanceSqr)
            {
                minDistanceSqr = distSqr;
                nearest = enemy;
            }
        }
        return nearest;
    }

    public float GetRadius() => _abilityRadius;
}