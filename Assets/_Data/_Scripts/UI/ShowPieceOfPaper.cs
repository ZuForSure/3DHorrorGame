using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPieceOfPaper : MyMonoBehaviour
{
    [SerializeField] protected List<GameObject> papers;
    protected int count = 0;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPapers();
    }

    private void FixedUpdate()
    {
        this.ShowPaperUptoUI();
    }

    protected virtual void LoadPapers()
    {
        if (this.papers.Count > 0) return;

        foreach (Transform child in transform)
        {
            this.papers.Add(child.gameObject);
        }

        this.HidePapers();
        Debug.Log(transform.name + ": LoadPapers", gameObject);
    }

    protected virtual void HidePapers()
    {
        foreach(GameObject child in this.papers)
        {
            child.SetActive(false);
        }
    }

    protected virtual void ShowPaperUptoUI()
    {
        if(this.count >= this.papers.Count) return;

        foreach(GameObject paper in this.papers)
        {
            if(Inventory.Instance.FindItem(paper.name) == null) continue;
            if(paper.activeSelf) continue;

            paper.SetActive(true);
            this.count++;
        }
    }
}
