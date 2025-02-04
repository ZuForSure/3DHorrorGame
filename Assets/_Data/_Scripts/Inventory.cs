using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MyMonoBehaviour
{
    protected static Inventory instance;
    public static Inventory Instance => instance;   

    [SerializeField] protected List<Transform> items;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 Inventory are allowed");
        Inventory.instance = this;
    }

    public virtual void AddItem(Transform item)
    {
        this.items.Add(item);
        item.gameObject.SetActive(false);
    }

    public virtual Transform FindItem(string itemName)
    {
        foreach (Transform item in this.items)
        {
            if (item.name != itemName) continue;
            return item;
        }

        return null;
    }
}
