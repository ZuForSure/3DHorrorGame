using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrAnAnimation : MyMonoBehaviour
{
    [SerializeField] protected Animator animTor;
    public bool isRunning = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected override void Update()
    {
        base.Update();
        this.RunAnimation();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animTor != null) return;
        this.animTor = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void RunAnimation()
    {
        this.animTor.SetBool("isRunning", this.isRunning);
    }
}
