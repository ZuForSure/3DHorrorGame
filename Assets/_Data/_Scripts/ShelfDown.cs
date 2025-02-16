using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfDown : MyMonoBehaviour
{
    [SerializeField] protected Animator animCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimatorCtrl();
    }

    protected virtual void LoadAnimatorCtrl()
    {
        if (this.animCtrl != null) return;
        this.animCtrl = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimatorCtrl", gameObject);
    }

    public virtual void ActiveTriggerShelfDown()
    {
        this.animCtrl.SetTrigger("isFall");
    }
}
