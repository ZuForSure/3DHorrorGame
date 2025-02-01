using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchLight : PlayerInteract
{
    [Header("Player Switch Light")]
    [SerializeField] protected LightSwitch lightSwitch;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.interactLayer = LayerMask.GetMask("SwitchLight");
    }

    protected override void OnInteract()
    {
        this.ToggleSwitchLight();
    }

    protected virtual void ToggleSwitchLight()
    {
        if (this.GetInteractObj().transform == null) return;

        if (this.GetInteractObj().transform.TryGetComponent(out this.lightSwitch))
        {
            if (this.lightSwitch.on) this.lightSwitch.TurnOff();
            else this.lightSwitch.TurnOn();
        }
    }
}
