using UnityEngine;

public class DoorOpenClose : MyMonoBehaviour
{
    [SerializeField] protected Animator doorAnimCtrl;
    [SerializeField] protected GameObject openCloseText;
    public bool isOpen = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDoorAnimator();
        this.LoadOpenCloseText();
    }

    protected virtual void LoadDoorAnimator()
    {
        if (this.doorAnimCtrl != null) return;
        this.doorAnimCtrl = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadDoorAnimator", gameObject);
    }

    protected virtual void LoadOpenCloseText()
    {
        if (this.openCloseText != null) return;
        this.openCloseText = GameObject.Find("OpenClose");
        Debug.Log(transform.name + ": LoadOpenCloseText", gameObject);
    }

    public virtual void Open()
    {
        this.doorAnimCtrl.SetBool("isOpen", true);
        this.doorAnimCtrl.SetBool("isClose", false);

        this.isOpen = true;
    }

    public virtual void Close() 
    {
        this.doorAnimCtrl.SetBool("isClose", true);
        this.doorAnimCtrl.SetBool("isOpen", false);

        this.isOpen = false;
    }
}
