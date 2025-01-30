using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenClose : PlayerInteract
{
    [Header("Player Open Close Door")]
    [SerializeField] protected OpenCloseAble openCloseAble;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.interactLayer = LayerMask.GetMask("OpenDoor");
    }

    protected override void OnInteract()
    {
        this.ToggleOpenClose();
    }

    protected virtual void ToggleOpenClose()
    {
        if (this.GetInteractObj().transform == null) return;

        if(this.GetInteractObj().transform.TryGetComponent(out this.openCloseAble))
        {
            if (this.openCloseAble.isOpen) this.openCloseAble.Close();
            else this.openCloseAble.Open();    
        }
    }
}
