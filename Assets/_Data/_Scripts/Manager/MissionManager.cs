using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissionManager : MyMonoBehaviour
{
    protected static MissionManager instance;
    public static MissionManager Instance => instance;

    [SerializeField] protected bool doneMission = false;
    public GameObject finalDoorCard;
    [SerializeField] protected JumpscareSpawn jumpscareSpawn;
    [SerializeField] protected List<WriteTheDeath> listMissions;
    public List<WriteTheDeath> ListMissions => listMissions;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMissions();
        this.LoadCard();
        this.LoadJumpscareSpawn();
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 MissionManager are allowed");
        MissionManager.instance = this;

        this.finalDoorCard.SetActive(false);
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

    protected virtual void LoadCard()
    {
        if (this.finalDoorCard != null) return;
        this.finalDoorCard = transform.GetChild(0).gameObject;
        Debug.Log(transform.name + ": LoadCard", gameObject);
    }

    protected virtual void LoadJumpscareSpawn()
    {
        if (this.jumpscareSpawn != null) return;
        this.jumpscareSpawn = GameObject.Find("Jumpscare Spawn").GetComponent<JumpscareSpawn>();
        Debug.Log(transform.name + ": LoadJumpscareSpawn", gameObject);
    }

    public virtual void HaveDoneAllMissions()
    {
        foreach(WriteTheDeath child in this.listMissions)
        {
            if (child.GetIsWrited()) continue;
            else return;
        }

        this.doneMission = true;
        this.ActiveTheFinalDoorCard();
        this.jumpscareSpawn.Spawn();
    }

    protected virtual void ActiveTheFinalDoorCard()
    {
        this.finalDoorCard.SetActive(true);
    }
}
