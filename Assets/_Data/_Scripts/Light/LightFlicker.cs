using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MyMonoBehaviour
{
    [SerializeField] protected Light lightFlicker;
    [SerializeField] protected float timer;
    [SerializeField] protected float minTime, maxTime;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLightFlicker();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.minTime = 0.25f;
        this.maxTime = 1.25f;
    }

    protected override void Start()
    {
        base.Start();
        this.timer = this.GetRandomTime();
    }

    protected override void Update()
    {
        base.Update();
        this.Flicker();
    }

    protected virtual void LoadLightFlicker()
    {
        if (this.lightFlicker != null) return;
        this.lightFlicker = transform.GetChild(1).GetComponent<Light>();
        Debug.Log(transform.name + ": LoadLightFlicker", gameObject);
    }

    protected virtual void Flicker()
    {
        if(this.timer > 0) this.timer -= Time.deltaTime;

        if(this.timer <= 0)
        {
            this.lightFlicker.enabled = !this.lightFlicker.enabled;
            this.timer = this.GetRandomTime();
        }
    }

    protected virtual float GetRandomTime()
    {
        return Random.Range(this.minTime, this.maxTime);
    }
}
