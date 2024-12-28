using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteract : PlayerAbstract
{
    [Header("Player Interact")]
    [SerializeField] protected LayerMask interactLayer;

    protected override void Update()
    {
        base.Update();
        this.CheckCanInteract();
    }

    protected virtual void CheckCanInteract()
    {
        if (!InputManager.Instance.IsClick) return;
        this.OnInteract();
    }

    protected virtual RaycastHit GetInteractObj()
    {
        float pickUpDistance = 1.8f;
        Physics.Raycast(this.playerCtrl.PlayerCam.position, this.playerCtrl.PlayerCam.forward, out RaycastHit hit, pickUpDistance, this.interactLayer);

        return hit;
    }

    protected abstract void OnInteract();
}
