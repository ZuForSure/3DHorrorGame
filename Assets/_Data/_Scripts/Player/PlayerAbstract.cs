using UnityEngine;

public abstract class PlayerAbstract : MyMonoBehaviour
{
    [Header("Player Abstract")]
    [SerializeField] protected PlayerController playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected virtual void LoadPlayerController()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerController>();
        Debug.Log(transform.name + ": LoadPlayerController", gameObject);
    }
}
