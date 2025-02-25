using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPaperInven : MyMonoBehaviour
{
    [SerializeField] protected GameObject hintPaper;

    protected override void Update()
    {
        this.ShowUI();
    }

    protected virtual void ShowUI()
    {
        if (!InputManager.Instance.TabInput) return;

        if (Inventory.Instance.FindItem(this.hintPaper.name) == null) return;
    }
}
