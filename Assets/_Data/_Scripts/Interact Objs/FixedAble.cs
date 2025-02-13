using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedAble : MyMonoBehaviour
{
    [SerializeField] protected GameObject sproket;
    [SerializeField] protected FinalDoor finalDoor;
    public GameObject Sproket => sproket;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSproket();
        this.LoadFinalDoor();
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
        Debug.Log(transform.name + ": LoadSproket", gameObject);
    }

    protected virtual void LoadFinalDoor()
    {
        if (this.finalDoor != null) return;
        this.finalDoor = GameObject.Find("Future_Door_Final").GetComponent<FinalDoor>();
        Debug.Log(transform.name + ": LoadFinalDoor", gameObject);
    }

    public virtual void Fixed()
    {
        if (Inventory.Instance.FindItem(this.sproket.name) == null) return;
        this.sproket.SetActive(true);
        this.finalDoor.OpenFinalDoor();
    }
}
