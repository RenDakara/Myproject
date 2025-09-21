using UnityEngine;

public class LifestealView : MonoBehaviour
{
    [SerializeField] private LifestealAbility _lifestealAbility;
    [SerializeField] private HealthSmoothSlider _healthSmoothSlider;
    [SerializeField] private Transform _abilityRadiusVisual;
    private float _radiusMultiplier = 2f;

    private void Awake()
    {
        if (_lifestealAbility != null)
        {
            _lifestealAbility.OnVisualStateChanged += HandleVisualStateChanged;
        }
        if (_abilityRadiusVisual != null)
        {
            float diameter = _lifestealAbility.GetRadius() * _radiusMultiplier;
            _abilityRadiusVisual.localScale = new Vector3(diameter, diameter, 1f);
            _abilityRadiusVisual.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (_lifestealAbility != null)
        {
            _lifestealAbility.OnVisualStateChanged -= HandleVisualStateChanged;
        }
    }

    private void HandleVisualStateChanged(bool active)
    {
        if (_abilityRadiusVisual != null)
            _abilityRadiusVisual.gameObject.SetActive(active);

        if (_healthSmoothSlider != null)
            _healthSmoothSlider.AnimateProgress();
    }
}