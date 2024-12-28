using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenClose : PlayerInteract
{
    [Header("Player Open Close Door")]
    [SerializeField] protected DoorOpenClose doorOpenClose;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.interactLayer = LayerMask.GetMask("OpenDoor");
    }

    protected override void OnInteract()
    {
        this.ToggleOpenCloseDoor();
    }

    protected virtual void ToggleOpenCloseDoor()
    {
        if (this.GetInteractObj().transform == null) return;

        if(this.GetInteractObj().transform.TryGetComponent(out this.doorOpenClose))
        {
            if (this.doorOpenClose.isOpen) this.doorOpenClose.Close();
            else this.doorOpenClose.Open();    
        }
    }
}
