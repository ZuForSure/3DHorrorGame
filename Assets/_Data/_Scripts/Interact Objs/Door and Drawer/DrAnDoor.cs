using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrAnDoor : OpenCloseAble
{
    [Header("Dr An Door")]
    [SerializeField] protected GameObject drAn;
    [SerializeField] protected AudioSource bgSource;
    [SerializeField] protected AudioClip bgChase;
    public bool canSetTarget = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameObj();
        this.LoadAudioSource();
    }

    protected virtual void LoadGameObj()
    {
        if (this.drAn != null) return;
        this.drAn = GameObject.Find("DrAn");
        Debug.Log(transform.name + ": LoadGameObj", gameObject);
    }

    protected virtual void LoadAudioSource()
    {
        if (this.bgSource != null) return;
        this.bgSource = GameObject.Find("BG Audio").GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadAudioSource", gameObject);
    }


    public override void Open()
    {
        if (!this.drAn.activeSelf) return;

        this.canSetTarget = true;
        this.bgSource.Stop();
        this.bgSource.PlayOneShot(this.bgChase);
        base.Open();
    }

    public override void Close()
    {
        this.canSetTarget = false;

        base.Close();   
    }
}
