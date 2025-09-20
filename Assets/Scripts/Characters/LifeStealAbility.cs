using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifestealAbility : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _abilityRadiusVisual;
    [SerializeField] private float _healthPerSec = 5f;
    [SerializeField] private float _abilityRadius = 10f;
    [SerializeField] private float _abilityTime = 6f;
    [SerializeField] private float _abilityCooldown = 4f;

    private bool _abilityOnCooldown = false;
    private bool _abilityActive = false;
    private Coroutine _abilityCoroutine;

    private LifestealCollider _lifestealCollider;
    private Player _player;
    private HealthSmoothSlider _healthSmoothSlider;
    private InputService _inputService;

    private void Awake()
    {
        _lifestealCollider = GetComponentInChildren<LifestealCollider>();
        _player = GetComponent<Player>();
        _healthSmoothSlider = GetComponent<HealthSmoothSlider>();
        _inputService = GetComponent<InputService>();

        _abilityRadiusVisual.localScale = new Vector3(_abilityRadius * 2f, _abilityRadius * 2f, 1f);
        _abilityRadiusVisual.gameObject.SetActive(false);

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
        _abilityRadiusVisual.gameObject.SetActive(true);

        if (_healthSmoothSlider != null)
            _healthSmoothSlider.AnimateProgress();

        float elapsed = 0f;

        while (elapsed < _abilityTime)
        {
            float healAmount = _healthPerSec * Time.deltaTime;
            LifestealEffect.ApplyEffect(_player, _lifestealCollider.EnemiesInRange, healAmount);
            elapsed += Time.deltaTime;
            yield return null;
        }

        _abilityActive = false;
        _lifestealCollider.SetActive(false);
        _abilityRadiusVisual.gameObject.SetActive(false);

        if (_healthSmoothSlider != null)
            _healthSmoothSlider.AnimateProgress();

        _abilityOnCooldown = true;
        yield return new WaitForSeconds(_abilityCooldown);
        _abilityOnCooldown = false;
    }
}
