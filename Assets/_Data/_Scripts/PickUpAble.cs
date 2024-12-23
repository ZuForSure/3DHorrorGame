using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAble : MyMonoBehaviour
{
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] protected Transform pickUpPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
    }

    private void FixedUpdate()
    {
        this.ShiftObjToPlayerHand();
    }

    protected virtual void LoadRigibody()
    {
        if (this._rb != null) return;
        this._rb = transform.GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected virtual void ShiftObjToPlayerHand()
    {
        if (this.pickUpPoint == null) return;
        Vector3 newPos = Vector3.Lerp(transform.position, this.pickUpPoint.position, Time.deltaTime * 20f);
        this._rb.MovePosition(newPos);
    }

    public virtual void PickUp(Transform pickUpPoint)
    {
        this.pickUpPoint = pickUpPoint;
        this._rb.useGravity = false;
    }

    public virtual void Drop()
    {
        this.pickUpPoint = null;
        this._rb.useGravity = true;
    }
}
