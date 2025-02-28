using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextForInteract))]

public class ShowGuide : MyMonoBehaviour
{
    [Header("Show Guide")]
    [SerializeField] protected TextForInteract textForInteract;
    [SerializeField] protected TextForGuide textForGuide;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextInteract();
        this.LoadTextGuide();
    }

    private void OnDisable()
    {
        this.ShowGuideText();
    }

    protected virtual void LoadTextInteract()
    {
        if (this.textForInteract != null) return;
        this.textForInteract = GetComponent<TextForInteract>();
        Debug.Log(transform.name + ": LoadTextInteract", gameObject);
    }

    protected virtual void LoadTextGuide()
    {
        if (this.textForGuide != null) return;
        this.textForGuide = GameObject.Find("Text For Guide").GetComponent<TextForGuide>();
        Debug.Log(transform.name + ": LoadTextGuide", gameObject);
    }

    protected virtual void ShowGuideText()
    {
        this.textForGuide.textMeshPro.SetText(this.textForInteract.GetGuideIfNeed());
    }
}

