using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MyMonoBehaviour
{
    protected static MissionManager instance;
    public static MissionManager Instance => instance;

    //[SerializeField] protected bool isUsedDrug = false;
    [SerializeField] protected bool doneMission = false;
    [SerializeField] protected List<WriteTheDeath> listMissions;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMissions();
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 MissionManager are allowed");
        MissionManager.instance = this;
    }

    protected virtual void LoadMissions()
    {
        if (this.listMissions.Count > 0) return;

        Transform missionHolder = GameObject.Find("Beds").transform;
        foreach(Transform child in missionHolder)
        {
            this.listMissions.Add(child.GetComponent<WriteTheDeath>());
        }
        Debug.Log(transform.name + ": LoadMissions", gameObject);
    }

    public virtual void HaveDoneAllMissions()
    {
        foreach(WriteTheDeath item in this.listMissions)
        {
            if (item.GetIsWrited()) continue;
            else return;
        }

        this.doneMission = true;
    }
}
