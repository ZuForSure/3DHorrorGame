using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseWithLocked : OpenCloseAble
{
    [Header("With Lock")]
    [SerializeField] protected Transform requiredKey;
    [SerializeField] protected bool status; //true for unlocked, false for locked

    public override void Open()
    {
        if (Inventory.Instance.FindItem(this.requiredKey.name) == null)
        {
            this.status = false;
            return;
        }

        this.status = true;
        base.Open();
    }
}
