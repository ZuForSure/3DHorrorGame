using UnityEngine;

public class LootAble : MyMonoBehaviour
{
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GameObject.Find("Player Controller").GetComponent<PlayerController>().PlayerInven;
        Debug.Log(transform.name + ": LoadInventory", gameObject);
    }

    public virtual void Add()
    {
        this.inventory.AddItem(transform);
        if (this.CheckLastChar()) AudioManager.Instance.PlayAudioClip("Key");
        else AudioManager.Instance.PlayAudioClip("Loot");
    }

    protected virtual bool CheckLastChar()
    {
        string str = transform.name;
        char lastChar = str[^1];

        if (lastChar.ToString() == "K") return true;
        else return false;
    }
}
