using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MyMonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected GameObject drAn;
    [SerializeField] protected DrAnDoor drAnDoor;
    [SerializeField] protected DrAnMovement drAnMovement;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 GameManager allowed");
        GameManager.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
        this.LoadMovement();
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        this.drAn = GameObject.Find("DrAn");
        this.spawnPoint = GameObject.Find("Spawn Point").transform;
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }

    protected virtual void LoadMovement()
    {
        if (this.drAnMovement != null) return;
        this.drAnMovement = GameObject.Find("DrAn").GetComponent<DrAnMovement>();
        Debug.Log(transform.name + ": LoadMovement", gameObject);
    }

    public virtual void ReloadWhenGameOver()
    {
        this.drAn.transform.position = this.spawnPoint.position;
        this.drAnMovement.agent.isStopped = true;
        this.drAnDoor.Close();
    }
}
