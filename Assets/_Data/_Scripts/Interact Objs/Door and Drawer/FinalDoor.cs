using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MyMonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected TextForInteract textFinalDoor;
    [SerializeField] protected FixedAble fixedAble;
    [SerializeField] protected DrAnMovement drAnMovement;
    [SerializeField] protected string newText;
    [SerializeField] protected string meetDrAnText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadTextForInteract();
        this.LoadFixedAble();
        this.LoadDrAnMovement();
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

    protected virtual void LoadDrAnMovement()
    {
        if (this.drAnMovement != null) return;
        this.drAnMovement = GameObject.Find("DrAn").GetComponent<DrAnMovement>();
        Debug.Log(transform.name + ": LoadDrAnMovement", gameObject);
    }

    public virtual void OpenFinalDoor()
    {
        if (!this.fixedAble.Sproket.activeSelf) return;
        if (Inventory.Instance.FindItem(MissionManager.Instance.finalDoorCard.name) == null) return;
        if (!this.drAnMovement.canOpenFinalDoor)
        {
            TriggerText.Instance.textMeshPro.SetText(this.meetDrAnText);
            return;
        }
            
        this.anim.SetTrigger("isOpen");
    }
    
    public virtual void SetTextFinalDoor()
    {
        this.textFinalDoor.SetInteractText(this.newText);
    }
}
