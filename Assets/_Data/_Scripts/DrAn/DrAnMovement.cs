using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrAnMovement : MyMonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] protected Transform target;
    [SerializeField] protected DrAnDoor drAnDoor;
    [SerializeField] protected Animator drAnAnim;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected float speed = 4f;
    public bool canOpenFinalDoor = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadAnim();
    }

    protected override void Update()
    {
        this.CheckOpenDrAnDoor();
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void LoadAnim()
    {
        if (this.drAnAnim != null) return;
        this.drAnAnim = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnim", gameObject);
    }

    protected virtual void CheckOpenDrAnDoor()
    {
        if (!this.drAnDoor.canSetTarget) return;

        StartCoroutine(this.SetDrAnTarget());
    }

    protected IEnumerator SetDrAnTarget()
    {
        yield return new WaitForSeconds(this.delay);
        this.drAnAnim.SetTrigger("isRun");
        this.canOpenFinalDoor = true;
        this.agent.isStopped = false;
        this.agent.SetDestination(this.target.transform.position);
    }
}
