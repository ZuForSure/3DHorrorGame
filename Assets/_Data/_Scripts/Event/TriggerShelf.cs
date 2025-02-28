using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShelf : MyMonoBehaviour
{
    [SerializeField] protected ShelfDown shelfDown;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShelfDown();
    }

    protected override void Start()
    {
        base.Start();
        transform.gameObject.SetActive(false);
    }

    protected virtual void LoadShelfDown()
    {
        if (this.shelfDown != null) return;
        this.shelfDown = GameObject.Find("shelf down").GetComponent<ShelfDown>();
        Debug.Log(transform.name + ": LoadShelfDown", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.shelfDown.ActiveTriggerShelfDown();
        transform.gameObject.SetActive(false);
    }
}
