using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextForInteract : MyMonoBehaviour
{
    [SerializeField] protected string text;

    public virtual string GetText()
    {
        if(this.text == null) return null;

        return this.text;
    }

    public virtual void SetInteractText(string text)
    {
        this.text = text;
    }
}
