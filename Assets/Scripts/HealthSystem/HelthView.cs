using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class HealthUIParent : MonoBehaviour
{
    protected Health Health;

    private void Awake()
    {
        Health = GetComponent<Health>();

        Health.HPChanged += OnHealthChanged;

        Initialize();
        UpdateUI();
    }

    private void OnDestroy()
    {
        if (Health != null)
            Health.HPChanged -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged()
    {
        UpdateUI();
    }

    protected virtual void Initialize() { }

    protected virtual void UpdateUI() { }
}
