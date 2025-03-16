using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerText : MyMonoBehaviour
{
    protected static TriggerText instance;
    public static TriggerText Instance => instance;

    public TextMeshProUGUI textMeshPro;
    [SerializeField] protected TextForInteract textInteract;
    [SerializeField] protected ReadNote readNote;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 TriggerText are allowed");
        TriggerText.instance = this;
    }

    private void FixedUpdate()
    {
        this.CheckObjActive();
    }

    protected virtual void LoadText()
    {
        if (this.textMeshPro != null) return;
        this.textMeshPro = GameObject.Find("Text Of Interact Obj").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadText", gameObject);
    }

    protected virtual void CheckObjActive()
    {
        if (this.textInteract == null) return;
        if (this.textInteract.gameObject.activeSelf) return;

        this.textMeshPro.gameObject.SetActive(false);
        this.textInteract = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("InteractObj")) return;

        this.textInteract = other.GetComponent<TextForInteract>();
        if (this.textInteract == null) return;
        this.textMeshPro.gameObject.SetActive(true);
        this.textMeshPro.SetText(this.textInteract.GetText());

        this.readNote = other.GetComponent<ReadNote>();
        if (this.readNote == null) return;
        this.readNote.ShowNoteUI();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("InteractObj")) return;

        this.textInteract = null;
        this.textMeshPro.gameObject.SetActive(false);

        if (this.readNote == null) return;
        this.readNote.HideNoteUI();
    }
}
