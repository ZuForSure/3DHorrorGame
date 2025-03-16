using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNote : MyMonoBehaviour
{
    [SerializeField] protected GameObject noteUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNoteUI();
    }

    protected override void Start()
    {
        base.Start();
        this.noteUI.SetActive(false);
    }

    protected virtual void LoadNoteUI()
    {
        if (this.noteUI != null) return;
        this.noteUI = GameObject.Find("Note UI");
        Debug.Log(transform.name + ": LoadNoteUI", gameObject);
    }

    public virtual void ShowNoteUI()
    {
        this.noteUI.SetActive(true);
    }

    public virtual void HideNoteUI()
    {
        this.noteUI.SetActive(false);
    }
}
