using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerText : MyMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshPro;
    [SerializeField] protected TextForInteract textInteract;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
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
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("InteractObj")) return;

        this.textInteract = null;
        this.textMeshPro.gameObject.SetActive(false);
    }
}
