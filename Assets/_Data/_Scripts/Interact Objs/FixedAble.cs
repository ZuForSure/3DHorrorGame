using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedAble : MyMonoBehaviour
{
    [SerializeField] protected GameObject sproket;
    [SerializeField] protected GameObject triggerShelf;
    [SerializeField] protected FinalDoor finalDoor;
    [SerializeField] protected TextForInteract textMotor;
    [SerializeField] protected string newtextMotor;

    public GameObject Sproket => sproket;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSproket();
        this.LoadFinalDoor();
        this.LoadTextForInteract();
    }

    protected override void Awake()
    {
        base.Awake();
        this.sproket.SetActive(false);
    }

    protected virtual void LoadSproket()
    {
        if (this.sproket != null) return;
        this.sproket = transform.GetChild(0).gameObject;
        this.triggerShelf = GameObject.Find("Trigger Shelf");
        Debug.Log(transform.name + ": LoadSproket", gameObject);
    }

    protected virtual void LoadFinalDoor()
    {
        if (this.finalDoor != null) return;
        this.finalDoor = GameObject.Find("Future_Door_Final").GetComponent<FinalDoor>();
        Debug.Log(transform.name + ": LoadFinalDoor", gameObject);
    }
    protected virtual void LoadTextForInteract()
    {
        if (this.textMotor != null) return;
        this.textMotor = transform.GetComponent<TextForInteract>();
        Debug.Log(transform.name + ": LoadTextForInteract", gameObject);
    }

    public virtual void Fixed()
    {
        if (Inventory.Instance.FindItem(this.sproket.name) == null) return;
        this.sproket.SetActive(true);
        this.triggerShelf.SetActive(true);
        this.textMotor.SetInteractText(this.newtextMotor);
        TriggerText.Instance.textMeshPro.SetText(this.newtextMotor);

        this.finalDoor.SetTextFinalDoor();
    }
}
