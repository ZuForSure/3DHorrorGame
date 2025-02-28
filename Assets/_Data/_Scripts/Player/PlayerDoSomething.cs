using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoSomething : PlayerInteract
{
    [Header("Player Do Something")]
    [SerializeField] protected InteractBarrel interactBarrel;
    [SerializeField] protected FixedAble fixedAble;
    [SerializeField] protected WriteTheDeath writeTheDeath;
    [SerializeField] protected FinalDoor finalDoor;
    [SerializeField] protected DrAnDoorText drDoorText;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.interactLayer = LayerMask.GetMask("DoingSomething");
    }

    protected override void OnInteract()
    {
        this.InteractWithBarrel();
        this.InteractWithMotor();
        this.InteractWithDeadVictims();
        this.OpenFinalDoor();
        this.ShowScriptDoorText();
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

    protected virtual void InteractWithMotor()
    {
        if (this.GetInteractObj().transform == null) return;

        if (this.GetInteractObj().transform.TryGetComponent(out this.fixedAble))
        {
            if (this.fixedAble.Sproket.activeSelf) return;
            this.fixedAble.Fixed();
        }
    }

    protected virtual void InteractWithDeadVictims()
    {
        if (this.GetInteractObj().transform == null) return;

        if (this.GetInteractObj().transform.TryGetComponent(out this.writeTheDeath))
        {
            this.writeTheDeath.Write();
        }
    }

    protected virtual void OpenFinalDoor()
    {
        if (this.GetInteractObj().transform == null) return;

        if (this.GetInteractObj().transform.TryGetComponent(out this.finalDoor))
        {
            this.finalDoor.OpenFinalDoor();
        }
    }

    protected virtual void ShowScriptDoorText()
    {
        if (this.GetInteractObj().transform == null) return;

        if (this.GetInteractObj().transform.TryGetComponent(out this.drDoorText))
        {
            this.drDoorText.ChangeUIWhenClick();
        }
    }
}
