using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoSomething : PlayerInteract
{
    [Header("Player Do Something")]
    [SerializeField] protected InteractBarrel interactBarrel;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.interactLayer = LayerMask.GetMask("DoingSomething");
    }

    protected override void OnInteract()
    {
        this.InteractWithBarrel();
    }

    protected virtual void InteractWithBarrel()
    {
        if (this.GetInteractObj().transform == null) return;

        if (this.GetInteractObj().transform.TryGetComponent(out this.interactBarrel))
        {
            if (!this.playerCtrl.Pickup.SometingOnHand) return;
            this.interactBarrel.BreakTheBarrel();
        }
    }
}
