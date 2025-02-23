using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MyMonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected TextForInteract textFinalDoor;
    [SerializeField] protected string newText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadTextForInteract();
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

    public virtual void OpenFinalDoor()
    {
        if (Inventory.Instance.FindItem(MissionManager.Instance.finalDoorCard.name) == null) return;
        this.anim.SetTrigger("isOpen");
    }
    
    public virtual void SetTextFinalDoor()
    {
        this.textFinalDoor.SetInteractText(this.newText);
    }
}
