using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGuideEndMission : ShowGuide
{
    [Header("Show Guide End Mission")]
    [SerializeField] protected FixedAble fixedAble;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFixedAble();
    }

    private void OnDisable()
    {
        this.ShowGuideText();
    }

    private void FixedUpdate()
    {
        this.CheckCanShowGuideEndTask();
    }

    protected virtual void LoadFixedAble()
    {
        if (this.fixedAble != null) return;
        this.fixedAble = GameObject.Find("ElectricMotorAndCraddle").GetComponent<FixedAble>();
        Debug.Log(transform.name + ": LoadFixedAble", gameObject);
    }

    protected virtual void CheckCanShowGuideEndTask()
    {
        if (!this.fixedAble.Sproket.activeSelf) return;
        if (Inventory.Instance.FindItem(this.GetCardFinalDoorName()) == null) return;

        transform.gameObject.SetActive(false);
    }

    protected virtual string GetCardFinalDoorName()
    {
        return MissionManager.Instance.finalDoorCard.name;
    }
}
