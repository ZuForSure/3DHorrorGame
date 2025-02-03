using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MyMonoBehaviour
{
    [SerializeField] protected List<Transform> items;
   
    public virtual void AddItem(Transform item)
    {
        this.items.Add(item);
        item.gameObject.SetActive(false);
    }
}
