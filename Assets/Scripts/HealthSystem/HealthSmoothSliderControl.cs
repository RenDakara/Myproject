using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSmoothSlider : HealthView
{
    [SerializeField] private Slider _slider;

    private float _smoothSpeed = 10f;
    private float _displayedHealth;
    private float _minDifference = 0.01f;

    private Coroutine _animationCoroutine;

    protected override void Initialize()
    {
        if (_slider != null && Health != null)
        {
            _slider.maxValue = Health.Max;
            _displayedHealth = Health.Current;
            _slider.value = _displayedHealth;
        }
    }

    protected override void OnHealthChanged()
    {
        base.OnHealthChanged();
        if (_animationCoroutine != null)
            StopCoroutine(_animationCoroutine);
        _animationCoroutine = StartCoroutine(AnimateSlider());
    }

    private IEnumerator AnimateSlider()
    {
        float startHealth = _displayedHealth; 
        float duration = 0.5f; 
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            _displayedHealth = Mathf.Lerp(startHealth, Health.Current, t);

            if (_slider != null)
                _slider.value = _displayedHealth;

            yield return null;
        }

        _displayedHealth = Health.Current;

        if (_slider != null)
            _slider.value = _displayedHealth;
    }
}
