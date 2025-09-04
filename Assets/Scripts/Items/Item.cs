using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Item : MonoBehaviour
{
    public event Action<Item> OnItemCollected;

    public virtual void Collect()
    {
        OnItemCollected?.Invoke(this);
        Destroy(gameObject);
    }
}
