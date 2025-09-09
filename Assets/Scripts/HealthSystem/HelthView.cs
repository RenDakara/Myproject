using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class HealthView : MonoBehaviour
{
    protected Health Health;

    private void Awake()
    {
        Health = GetComponent<Health>();

        Health.ValueChanged += OnHealthChanged;

        Initialize();
        UpdateUI();
    }

    private void OnDestroy()
    {
        if (Health != null)
            Health.ValueChanged -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged()
    {
        UpdateUI();
    }

    protected virtual void Initialize() { }

    protected virtual void UpdateUI() { }
}
