using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MyMonoBehaviour
{
    [SerializeField] protected Transform playerCam;
    [SerializeField] protected Transform pickUpPoint;
    public Transform PlayerCam => playerCam;
    public Transform PickUpPoint => pickUpPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCam();
        this.LoadPickUpPoint();
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
        Debug.Log(transform.name + ": LoadPickUpPoint", gameObject);
    }
}