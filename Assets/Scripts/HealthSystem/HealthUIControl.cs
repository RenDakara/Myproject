using TMPro;
using UnityEngine;

public class HealthUIControl : HealthUIParent
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void UpdateUI()
    {
        if (_text != null && Health != null)
        {
            _text.text = $"���� �������� {Health.Max} ||| �������� {Health.Current}";
        }
    }

    public void ShowHealth()
    {
        UpdateUI();
    }
}
