using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareSpawn : MyMonoBehaviour
{
    [SerializeField] protected GameObject jumpscare;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJumpscareObj();
    }

    protected override void Start()
    {
        base.Start();
        this.jumpscare.SetActive(false);
    }

    protected virtual void LoadJumpscareObj()
    {
        if (this.jumpscare != null) return;
        this.jumpscare = GameObject.Find("Jumpscare");
        Debug.Log(transform.name + ": LoadJumpscareObj", gameObject);
    }

    public virtual void Spawn()
    {
        this.jumpscare.SetActive(true);
    }
}
