using UnityEngine;

public class PlayerPickUpDrop : PlayerInteract
{
    [Header("Pick Up And Drop")]
    [SerializeField] protected PickUpAble pickUpAble;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.interactLayer = LayerMask.GetMask("PickUpAbleObjs");
    }

    protected override void OnInteract()
    {
        this.TogglePickUpDrop();
    }

    protected virtual void TogglePickUpDrop()
    {
        if (this.pickUpAble == null)
        {
            //Not carry an obj, try to pick it up
            if (this.GetInteractObj().transform != null)
            {
                if (this.GetInteractObj().transform.TryGetComponent(out this.pickUpAble))
                {
                    this.pickUpAble.PickUp(this.playerCtrl.PickUpPoint);
                    this.playerCtrl.AxeInHand.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            this.pickUpAble.Drop(this.playerCtrl.DropPoint);
            this.playerCtrl.AxeInHand.gameObject.SetActive(false);
            this.pickUpAble = null;
        }
    }
}
