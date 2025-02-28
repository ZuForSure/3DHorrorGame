using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextForInteract : MyMonoBehaviour
{
    [Header("Text for Interact")]
    [SerializeField] protected string text;
    [SerializeField] protected string guideIfNeed;

    public virtual string GetText()
    {
        if(this.text == null) return null;

        return this.text;
    }

    public virtual string GetGuideIfNeed()
    {
        if (this.guideIfNeed == null) return null;

        return this.guideIfNeed;
    }

    public virtual void SetInteractText(string text)
    {
        this.text = text;
    }
}
