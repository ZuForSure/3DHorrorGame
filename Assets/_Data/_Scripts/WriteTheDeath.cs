using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteTheDeath : MyMonoBehaviour
{
    [SerializeField] protected TextForInteract interactText;
    [SerializeField] protected bool isWrited = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextForInteract();
    }

    protected virtual void LoadTextForInteract()
    {
        if (this.interactText != null) return;
        this.interactText = transform.GetComponent<TextForInteract>();
        Debug.Log(transform.name + ": LoadTextForInteract", gameObject);
    }

    public virtual void Write()
    {
        if (this.isWrited) return;

        this.isWrited = true;
        this.ChangeTheText();
        this.CheckDoneMission();
        TriggerText.Instance.textMeshPro.SetText("Done");
    }

    protected virtual void ChangeTheText()
    {
        this.interactText.SetInteractText("Done");
    }

    protected virtual void CheckDoneMission()
    {
        MissionManager.Instance.HaveDoneAllMissions();
    }

    public virtual bool GetIsWrited()
    {
        return this.isWrited;
    }
}