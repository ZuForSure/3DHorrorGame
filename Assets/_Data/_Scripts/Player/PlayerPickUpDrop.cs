using UnityEngine;

public class PlayerPickUpDrop : PlayerInteract
{
    [Header("Pick Up And Drop")]
    [SerializeField] protected PickUpAble pickUpAble;
    public bool somethingOnHand = false;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.interactLayer = LayerMask.GetMask("PickUpAbleObjs");
        this.somethingOnHand = false;
    }

    protected override void CheckCanInteract()
    {
        if (!InputManager.Instance.EInput) return;
        this.OnInteract();
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
                    this.somethingOnHand = true;
                }
            }
        }
        else
        {
            this.pickUpAble.Drop(this.playerCtrl.DropPoint);
            this.playerCtrl.AxeInHand.gameObject.SetActive(false);
            this.somethingOnHand = false;
            this.pickUpAble = null;
        }
    }
}
