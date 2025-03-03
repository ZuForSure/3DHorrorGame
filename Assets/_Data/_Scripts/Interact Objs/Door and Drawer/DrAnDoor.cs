using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrAnDoor : OpenCloseAble
{
    [Header("Dr An Door")]
    [SerializeField] protected GameObject drAn;
    public bool canSetTarget = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameObj();
    }

    protected virtual void LoadGameObj()
    {
        if (this.drAn != null) return;
        this.drAn = GameObject.Find("DrAn");
        Debug.Log(transform.name + ": LoadGameObj", gameObject);
    }

    public override void Open()
    {
        if (!this.drAn.activeSelf) return;

        this.canSetTarget = true;
        base.Open();
    }
}
