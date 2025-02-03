using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooting : PlayerInteract
{
    [Header("Player Looting")]
    [SerializeField] protected LootAble lootAble;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.interactLayer = LayerMask.GetMask("LootAble");
    }

    protected override void OnInteract()
    {
        this.AddItemIntoInventory();
    }

    protected virtual void AddItemIntoInventory()
    {
        if (this.GetInteractObj().transform == null) return;

        if (this.GetInteractObj().transform.TryGetComponent(out this.lootAble))
        {
            this.lootAble.Add();
        }
    }
}
