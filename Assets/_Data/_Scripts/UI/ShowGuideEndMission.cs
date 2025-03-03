using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGuideEndMission : ShowGuide
{
    [Header("Show Guide End Mission")]
    [SerializeField] protected FixedAble fixedAble;
    [SerializeField] protected GameObject drAn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFixedAble();
        this.LoadGameObj();
    }

    protected override void Start()
    {
        this.drAn.SetActive(false);
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

    protected virtual void LoadGameObj()
    {
        if (this.drAn != null) return;
        this.drAn = GameObject.Find("DrAn");
        Debug.Log(transform.name + ": LoadGameObj", gameObject);
    }

    protected virtual void CheckCanShowGuideEndTask()
    {
        if (!this.fixedAble.Sproket.activeSelf) return;
        if (Inventory.Instance.FindItem(this.GetCardFinalDoorName()) == null) return;

        this.drAn.SetActive(true);
        transform.gameObject.SetActive(false);
    }

    protected virtual string GetCardFinalDoorName()
    {
        return MissionManager.Instance.finalDoorCard.name;
    }
}
