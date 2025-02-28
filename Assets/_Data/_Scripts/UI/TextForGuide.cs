using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextForGuide : MyMonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    [SerializeField] protected float time2Show = 5f;
    [SerializeField] protected float timer = 0f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    private void FixedUpdate()
    {
        this.ResetTextWhenTimeOut();
    }

    protected virtual void LoadText()
    {
        if (this.textMeshPro != null) return;
        this.textMeshPro = GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadText", gameObject);
    }

    protected virtual void ResetTextWhenTimeOut()
    {
        if (this.textMeshPro.text == null) return;

        this.timer += Time.fixedDeltaTime;
        if(this.timer >= this.time2Show)
        {
            this.textMeshPro.text = null;
            this.timer = 0f;
        }
    }
}
