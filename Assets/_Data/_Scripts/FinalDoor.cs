using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MyMonoBehaviour
{
    [SerializeField] protected Animator anim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (this.anim != null) return;
        this.anim = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    public virtual void OpenFinalDoor()
    {
        this.anim.SetTrigger("isOpen");
    }
}
