using UnityEngine;

public class OpenCloseAble : MyMonoBehaviour
{
    [SerializeField] protected Animator animCtrl;
    public bool isOpen = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animCtrl != null) return;
        this.animCtrl = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadDoorAnimator", gameObject);
    }

    public virtual void Open()
    {
        this.animCtrl.SetBool("isOpen", true);
        this.animCtrl.SetBool("isClose", false);

        this.isOpen = true;
    }

    public virtual void Close() 
    {
        this.animCtrl.SetBool("isClose", true);
        this.animCtrl.SetBool("isOpen", false);

        this.isOpen = false;
    }
}
