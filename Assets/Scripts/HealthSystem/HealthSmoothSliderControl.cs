using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSmoothSlider : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _progressSlider;

    private float _displayedHealth;

    private Coroutine _animationCoroutine;
    private Coroutine _progressCoroutine;

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
            float time = Mathf.Clamp01(elapsedTime / duration);
            _displayedHealth = Mathf.Lerp(startHealth, Health.Current, time);

            if (_slider != null)
                _slider.value = _displayedHealth;

            yield return null;
        }

        _displayedHealth = Health.Current;

        if (_slider != null)
            _slider.value = _displayedHealth;
    }

    public void AnimateProgress()
    {
        if (_progressCoroutine != null)
            StopCoroutine(_progressCoroutine);
        _progressCoroutine = StartCoroutine(ProgressSequence());
    }

    private IEnumerator ProgressSequence()
    {
        float decreaseTime = 6f;
        float restoreTime = 4f;

        float startValue = _progressSlider.value;

        float elapsed = 0f;
        while (elapsed < decreaseTime)
        {
            float time = elapsed / decreaseTime;
            _progressSlider.value = Mathf.Lerp(startValue, elapsed, time);
            elapsed += Time.deltaTime;
            yield return null;
        }
        _progressSlider.value = 0f;

        float restoreElapsed = 0f;
        float fromValue = _progressSlider.value; 
        float toValue = 100f;
        while (restoreElapsed < restoreTime)
        {
            float time = restoreElapsed / restoreTime;
            _progressSlider.value = Mathf.Lerp(fromValue, toValue, time);
            restoreElapsed += Time.deltaTime;
            yield return null;
        }
        _progressSlider.value = toValue;
    }
}
