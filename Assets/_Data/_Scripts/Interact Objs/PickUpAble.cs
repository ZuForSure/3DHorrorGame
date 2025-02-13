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

    protected virtual void LoadRigibody()
    {
        if (this._rb != null) return;
        this._rb = transform.GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    public virtual void PickUp(Transform pickUpPoint)
    {
        this.pickUpPoint = pickUpPoint;
        this._rb.useGravity = false;

        transform.gameObject.SetActive(false);
    }

    public virtual void Drop(Transform dropPoint)
    {
        this.pickUpPoint = null;
        transform.position = dropPoint.position;

        this._rb.useGravity = true;
        transform.gameObject.SetActive(true);
    }
}
