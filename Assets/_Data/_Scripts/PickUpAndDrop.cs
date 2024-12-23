using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : PlayerAbstract
{
    [Header("Pick Up And Drop")]
    [SerializeField] protected LayerMask pickUpLayer;
    private PickUpAble pickUpAble;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.pickUpLayer = LayerMask.GetMask("PickUpAbleObjs");
    }

    protected override void Update()
    {
        base.Update();
        this.TogglePickUpDrop();
    }

    protected virtual void TogglePickUpDrop()
    {
        if (!InputManager.Instance.IsClick) return;

        float pickUpDistance = 1.8f;
        if (this.pickUpAble == null) 
        {
            //Not carry an obj, try to pick it up
            if (Physics.Raycast(this.playerCtrl.PlayerCam.position, this.playerCtrl.PlayerCam.forward, out RaycastHit hit, pickUpDistance, this.pickUpLayer))
            {
                if (hit.transform.TryGetComponent(out this.pickUpAble))
                {
                    this.pickUpAble.PickUp(this.playerCtrl.PickUpPoint);
                }
            }
        }
        else
        {
            this.pickUpAble.Drop(this.playerCtrl.DropPoint);
            this.pickUpAble = null;
        }
    }
}
