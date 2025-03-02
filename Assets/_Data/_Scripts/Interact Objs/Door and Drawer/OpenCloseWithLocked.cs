using UnityEngine;

public class OpenCloseWithLocked : OpenCloseAble
{
    [Header("With Lock")]
    [SerializeField] protected Transform requiredKey;
    [SerializeField] protected string lockedDoorText = "it is locked";
    [SerializeField] protected bool status; //true for unlocked, false for locked

    public override void Open()
    {
        if (Inventory.Instance.FindItem(this.requiredKey.name) == null)
        {
            this.status = false;
            this.SetTextLockedDoor();
            this.PlayLockedSound();
            return;
        }

        this.status = true;
        base.Open();
    }

    protected virtual void SetTextLockedDoor()
    {
        TriggerText.Instance.textMeshPro.SetText(this.lockedDoorText);
    }

    protected virtual void PlayLockedSound()
    {
        AudioManager.Instance.PlayAudioClip("LockedDoor");
    }
}
