using TMPro;
using UnityEngine;

public class HealthUIControl : HealthView
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void UpdateUI()
    {
        if (_text != null && Health != null)
        {
            _text.text = $"Макс здоровье {Health.Max} ||| Здоровье {Health.Current}";
        }
    }

    public void ShowHealth()
    {
        UpdateUI();
    }
}
