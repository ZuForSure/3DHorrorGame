using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsTabToggleUI : MyMonoBehaviour
{
    [SerializeField] protected Animator animCtrl;
    [SerializeField] protected bool open, close;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected override void Start()
    {
        base.Start();
        this.open = false;
        this.close = true;
    }

    protected override void Update()
    {
        this.ToggleOpenCloseUI();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animCtrl != null) return;
        this.animCtrl = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadDoorAnimator", gameObject);
    }

    protected virtual void ToggleOpenCloseUI()
    {
        if (!InputManager.Instance.TabInput) return;

        if (this.close)
        {
            this.open = true;
            this.close = false;
            this.animCtrl.SetBool("isOpen", true);
            return;
        }
        else if (this.open)
        {
            this.close = true;
            this.open = false;
            this.animCtrl.SetBool("isOpen", false);
            return;
        }
    }
}
