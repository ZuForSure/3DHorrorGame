using UnityEngine;

public class WriteTheDeath : MyMonoBehaviour
{
    [SerializeField] protected TextForInteract interactText;
    [SerializeField] protected bool isWrited = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextForInteract();
    }

    protected virtual void LoadTextForInteract()
    {
        if (this.interactText != null) return;
        this.interactText = transform.GetComponent<TextForInteract>();
        Debug.Log(transform.name + ": LoadTextForInteract", gameObject);
    }

    public virtual void Write()
    {
        if (this.isWrited) return;

        this.isWrited = true;
        this.interactText.SetInteractText("Done");

        MissionManager.Instance.HaveDoneAllMissions();
        TriggerText.Instance.textMeshPro.SetText("Done");
        AudioManager.Instance.PlayAudioClip("Write");
    }

    public virtual bool GetIsWrited()
    {
        return this.isWrited;
    }
}