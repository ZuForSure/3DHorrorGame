using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MyMonoBehaviour
{
    [SerializeField] protected GameObject flashLight;
    [SerializeField] protected bool on, off;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFlashLight();
    }

    protected override void Start()
    {
        base.Start();
        this.on = false;
        this.off = true;
        this.flashLight.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();
        this.ToggleFlashLight();
    }

    protected virtual void LoadFlashLight()
    {
        if (this.flashLight != null) return;
        this.flashLight = GameObject.Find("Flash Light");
        Debug.Log(transform.name + ": LoadFlashLight", gameObject);
    }

    protected virtual void ToggleFlashLight()
    {
        if(this.on && InputManager.Instance.F_input)
        {
            this.flashLight.SetActive(false);
            this.on = false;
            this.off = true;
        } 
        else if(this.off && InputManager.Instance.F_input)
        {
            this.flashLight.SetActive(true);
            this.on = true;
            this.off = false;
        }
    }

}
