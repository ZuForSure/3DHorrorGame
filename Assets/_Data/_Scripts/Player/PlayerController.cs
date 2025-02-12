using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MyMonoBehaviour
{
    [SerializeField] protected PlayerPickUpDrop pickup;
    [SerializeField] protected Transform playerCam;
    [SerializeField] protected Transform pickUpPoint;
    [SerializeField] protected Transform dropPoint;
    [SerializeField] protected Transform axeInHand;
    [SerializeField] protected Inventory playerInven;
    public PlayerPickUpDrop Pickup => pickup;
    public Transform PlayerCam => playerCam;
    public Transform PickUpPoint => pickUpPoint;
    public Transform DropPoint => dropPoint;
    public Transform AxeInHand => axeInHand;
    public Inventory PlayerInven => playerInven;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickUp();
        this.LoadPlayerCam();
        this.LoadPickUpPoint();
        this.LoadPlayerInven();
    }

    protected virtual void LoadPlayerPickUp()
    {
        if (this.pickup != null) return;
        this.pickup = transform.GetComponentInChildren<PlayerPickUpDrop>();
        Debug.Log(transform.name + ": LoadPlayerPickUp", gameObject);
    }

    protected virtual void LoadPlayerCam()
    {
        if (this.playerCam != null) return;
        this.playerCam = GameObject.Find("First Person Camera").transform;
        Debug.Log(transform.name + ": LoadPlayerCam", gameObject);
    }

    protected virtual void LoadPickUpPoint()
    {
        if (this.pickUpPoint != null) return;
        this.pickUpPoint = this.playerCam.GetChild(0).transform;
        this.axeInHand = this.pickUpPoint.GetChild(0).transform;
        this.dropPoint = this.playerCam.GetChild(1).transform;
        Debug.Log(transform.name + ": LoadPickUpPoint", gameObject);
    }

    protected virtual void LoadPlayerInven()
    {
        if (this.playerInven != null) return;
        this.playerInven = transform.GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadPlayerInven", gameObject);
    }
}
