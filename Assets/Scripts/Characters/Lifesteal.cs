using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifesteal : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _healthPerSec = 5f;
    [SerializeField] private float _abilityRadius = 10f;
    [SerializeField] private Transform _abilityRadiusVisual;

    private InputService _inputService;
    private Coroutine _abilityCoroutine;

    private float _abilityTime = 6f;
    private float _abilityCooldown = 4f;
    private float _radiusMultiplyer = 2f;
    private float _standardDepth = 1f;
    private bool _abilityOnCooldown = false;
    private bool _abilityActive = false;
    private CircleCollider2D _drainCollider;
    private List<Health> _enemysInRange = new List<Health>();

    private void Awake()
    {
        _drainCollider = gameObject.AddComponent<CircleCollider2D>();
        _drainCollider.isTrigger = true;
        _drainCollider.radius = _abilityRadius;
        _drainCollider.enabled = false;
        _drainCollider.gameObject.layer = LayerMask.NameToLayer("Ability");
        _inputService = GetComponent<InputService>();
        _player = GetComponent<Player>();
        _player = FindObjectOfType<Player>();

        if(_abilityRadius != null)
        {
            float diameter = _abilityRadius * _radiusMultiplyer;
            _abilityRadiusVisual.localScale = new Vector3(diameter, diameter, _standardDepth);
            _abilityRadiusVisual.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_inputService.GetLifestealInput() && !_abilityOnCooldown && !_abilityActive)
            _abilityCoroutine = StartCoroutine(ToggleAbility());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_abilityOnCooldown) return;

        if (collision.TryGetComponent(out Enemy enemy))
        {
            Health enemyHealth = enemy.GetComponent<Health>();

            if (enemyHealth != null && !_enemysInRange.Contains(enemyHealth))
                _enemysInRange.Add(enemyHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            Health enemyHealth = enemy.GetComponent<Health>();

            if (enemyHealth != null)
                _enemysInRange.Remove(enemyHealth);
        }
    }

    private IEnumerator ToggleAbility()
    {
        _abilityActive = true;
        _drainCollider.enabled = true;
        _abilityRadiusVisual.gameObject.SetActive(true);

        float elapsed = 0f;

        while (elapsed < _abilityTime)
        {
            float healAmount = _healthPerSec * Time.deltaTime;

            for (int i = _enemysInRange.Count - 1; i >= 0; i--)
            {
                var enemyHealth = _enemysInRange[i];

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(healAmount);
                    _player.Heal(healAmount);
                }
                else
                {
                    _enemysInRange.RemoveAt(i);
                }
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        _abilityActive = false;
        _drainCollider.enabled = false;
        _abilityRadiusVisual.gameObject.SetActive(false);

        _abilityOnCooldown = true;
        yield return new WaitForSeconds(_abilityCooldown);
        _abilityOnCooldown = false;
    }
}
