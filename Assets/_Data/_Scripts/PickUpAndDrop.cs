using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MyMonoBehaviour
{
    [SerializeField] protected Transform playerCamPos;
    [SerializeField] protected LayerMask pickUpLayer;

    protected override void Update()
    {
        base.Update();
        this.TogglePickUpDrop();
    }

    protected virtual void TogglePickUpDrop()
    {
        if (!InputManager.Instance.IsClick) return;

        float pickUpDistance = 2f;
        if (Physics.Raycast(this.playerCamPos.position, this.playerCamPos.forward,out RaycastHit hit ,pickUpDistance, this.pickUpLayer))
        {
            Debug.Log(hit.transform);
        }
    }
}
