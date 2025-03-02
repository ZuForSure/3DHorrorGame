using UnityEngine;

public class OpenCloseAble : MyMonoBehaviour
{
    [Header("Open Close Able")]
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
        AudioManager.Instance.PlayAudioClip(transform.name);

        this.isOpen = true;
    }

    public virtual void Close() 
    {
        this.animCtrl.SetBool("isClose", true);
        this.animCtrl.SetBool("isOpen", false);
        AudioManager.Instance.PlayAudioClip(transform.name);

        //Bad idea
        if(transform.name == "Door")
        {
            AudioManager.Instance.PlayAudioClip(transform.name + "Close");
        }

        this.isOpen = false;
    }
}
