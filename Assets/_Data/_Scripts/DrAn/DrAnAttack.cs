using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrAnAttack : MyMonoBehaviour
{
    [SerializeField] protected Animator drAnAnim;
    [SerializeField] protected DrAnMovement movement;
    [SerializeField] protected GameObject playerCam;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnim();
    }

    protected virtual void LoadAnim()
    {
        if (this.drAnAnim != null) return;
        this.drAnAnim = transform.parent.GetComponent<Animator>();
        this.movement = transform.parent.GetComponent<DrAnMovement>();
        Debug.Log(transform.name + ": LoadAnim", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        Destroy(this.movement);
        Destroy(this.playerCam.GetComponent<FirstPersonLook>());
        this.playerCam.transform.LookAt(transform);
        this.drAnAnim.SetTrigger("isAttack");
    }
}
