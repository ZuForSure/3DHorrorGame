using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRun : MyMonoBehaviour
{
    public float speed = 5f;
    [SerializeField] protected Rigidbody rb;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
    }

    protected virtual void LoadRigibody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }

    protected override void Start()
    {
        this.rb.velocity = transform.forward * this.speed;
    }
}
