using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfDown : MyMonoBehaviour
{
    [SerializeField] protected Animator animCtrl;
    [SerializeField] protected AudioSource auSource;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimatorCtrl();
        this.LoadAudioSource();
    }

    protected virtual void LoadAnimatorCtrl()
    {
        if (this.animCtrl != null) return;
        this.animCtrl = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimatorCtrl", gameObject);
    }

    protected virtual void LoadAudioSource()
    {
        if (this.auSource != null) return;
        this.auSource = GetComponentInChildren<AudioSource>();
        Debug.Log(transform.name + ": LoadAudioSource", gameObject);
    }

    public virtual void ActiveTriggerShelfDown()
    {
        this.animCtrl.SetTrigger("isFall");
        this.auSource.Play();
    }
}
