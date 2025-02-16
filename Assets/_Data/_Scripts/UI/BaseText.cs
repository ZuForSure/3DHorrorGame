using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseText : MyMonoBehaviour
{
    [Header("Base Text")]
    protected static BaseText instance;
    public static BaseText Instance => instance;

    [SerializeField] protected TextMeshProUGUI textInteractObj;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 BaseText allowed");
        BaseText.instance = this;

        transform.gameObject.SetActive(false);
    }

    protected virtual void LoadText()
    {
        if (this.textInteractObj != null) return;
        this.textInteractObj = transform.GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadText", gameObject);
    }

    public virtual void SetText(string text)
    {
        this.textInteractObj.text = text;
    }
}
