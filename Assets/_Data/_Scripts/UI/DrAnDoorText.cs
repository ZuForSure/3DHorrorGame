using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrAnDoorText : TextForInteract
{
    [Header("Dr An Door Text")]
    [SerializeField] protected List<string> scripts;
    [SerializeField] protected int scriptsNum = 0;

    public virtual void ChangeUIWhenClick()
    {
        if(this.scriptsNum >= this.scripts.Count) this.scriptsNum = 0;

        TriggerText.Instance.textMeshPro.SetText(this.scripts[scriptsNum]);
        this.scriptsNum++;
    }
}
