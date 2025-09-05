using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : HealthView
{
    [SerializeField] private Slider _slider;

    protected override void Initialize()
    {
        if (_slider != null && Health != null)
        {
            _slider.maxValue = Health.Max;
            _slider.value = Health.Current;
        }
    }

    protected override void UpdateUI()
    {
        if (_slider != null && Health != null)
            _slider.value = Health.Current;
    }
}
