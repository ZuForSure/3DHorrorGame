using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseWithLocked : OpenCloseAble
{
    [Header("With Lock")]
    [SerializeField] protected Transform requiredKey;
    [SerializeField] protected string lockedDoorText = "it is locked";
    [SerializeField] protected bool status; //true for unlocked, false for locked

    public override void Open()
    {
        if (Inventory.Instance.FindItem(this.requiredKey.name) == null)
        {
            this.status = false;
            this.SetTextLockedDoor();
            return;
        }

        this.status = true;
        base.Open();
    }

    protected virtual void SetTextLockedDoor()
    {
        TriggerText.Instance.textMeshPro.SetText(this.lockedDoorText);
    }
}
