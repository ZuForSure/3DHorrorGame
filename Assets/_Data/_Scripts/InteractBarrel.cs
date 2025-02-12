using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractBarrel : MyMonoBehaviour
{
    [SerializeField] protected GameObject brokenBarrel;
    [SerializeField] protected GameObject neededObj;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBrokenBarrel();
    }

    protected virtual void LoadBrokenBarrel()
    {
        if (this.brokenBarrel != null) return;
        this.brokenBarrel = GameObject.Find("Broken Barrel");
        this.neededObj = GameObject.Find("Axe");
        Debug.Log(transform.name + ": LoadBrokenBarrel", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.brokenBarrel.SetActive(false);
    }

    public virtual void BreakTheBarrel()
    {
        this.brokenBarrel.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
