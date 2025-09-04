using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class HealthUIParent : MonoBehaviour
{
    protected Health Health;

    private void Awake()
    {
        Health = GetComponent<Health>();

        Health.HealthChanged += OnHealthChanged;

        Initialize();
        UpdateUI();
    }

    private void OnDestroy()
    {
        if (Health != null)
            Health.HealthChanged -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged()
    {
        UpdateUI();
    }

    protected virtual void Initialize() { }

    protected virtual void UpdateUI() { }
}
