using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveJumpscare : MyMonoBehaviour
{
    [SerializeField] protected GameObject jumpscare;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJumpScare();
    }

    protected override void Start()
    {
        base.Start();
        this.jumpscare.SetActive(false);
    }

    protected virtual void LoadJumpScare()
    {
        if (this.jumpscare != null) return;
        this.jumpscare = GameObject.Find("Jumpscare1");
        Debug.Log(transform.name + ": LoadJumpScare", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        this.jumpscare.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
