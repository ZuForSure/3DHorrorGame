using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextForInteract : MyMonoBehaviour
{
    [SerializeField] protected string text;

    public string GetText()
    {
        if(this.text == null) return null;

        return this.text;
    }
}
