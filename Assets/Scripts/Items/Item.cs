using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public event Action<Item> OnItemCollected;

    public virtual void Collect()
    {
        OnItemCollected?.Invoke(this);
        Destroy(gameObject);
    }
}