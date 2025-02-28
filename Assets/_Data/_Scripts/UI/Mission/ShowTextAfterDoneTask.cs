using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextAfterDoneTask : MyMonoBehaviour
{
    [SerializeField] protected List<GameObject> hiddenTexts;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHiddenTexts();
    }

    private void FixedUpdate()
    {
        this.UpdateMissonsUI();
    }

    protected virtual void LoadHiddenTexts()
    {
        if (this.hiddenTexts.Count > 0) return;

        foreach (Transform child in transform)
        {
            this.hiddenTexts.Add(child.gameObject);
        }
        Debug.Log(transform.name + ": LoadHiddenTexts", gameObject);
    }

    protected virtual void UpdateMissonsUI()
    {
        for(int i = 0; i < MissionManager.Instance.ListMissions.Count; i++)
        {
            WriteTheDeath mission = MissionManager.Instance.ListMissions[i];
            if (!mission.GetIsWrited()) continue;

            this.hiddenTexts[i].SetActive(false);
        }
    }
}
