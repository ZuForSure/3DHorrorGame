using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MyMonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected TextForInteract textFinalDoor;
    [SerializeField] protected FixedAble fixedAble;
    [SerializeField] protected string newText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadTextForInteract();
        this.LoadFixedAble();
    }

    protected virtual void LoadAnimator()
    {
        if (this.anim != null) return;
        this.anim = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadTextForInteract()
    {
        if (this.textFinalDoor != null) return;
        this.textFinalDoor = transform.GetComponent<TextForInteract>();
        Debug.Log(transform.name + ": LoadTextForInteract", gameObject);
    }

    protected virtual void LoadFixedAble()
    {
        if (this.fixedAble != null) return;
        this.fixedAble = GameObject.Find("ElectricMotorAndCraddle").GetComponent<FixedAble>();
        Debug.Log(transform.name + ": LoadFixedAble", gameObject);
    }

    public virtual void OpenFinalDoor()
    {
        if (!this.fixedAble.Sproket.activeSelf) return;
        if (Inventory.Instance.FindItem(MissionManager.Instance.finalDoorCard.name) == null) return;
        this.anim.SetTrigger("isOpen");
    }
    
    public virtual void SetTextFinalDoor()
    {
        this.textFinalDoor.SetInteractText(this.newText);
    }
}
