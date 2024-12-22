using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Start()
    {
        //FOR OVERRIDE
    }

    protected virtual void Update()
    {
        //FOR OVERRIDE
    }

    protected virtual void LoadComponents()
    {
        //FOR OVERRIDE
    }

    protected virtual void ResetValue()
    {
        //FOR OVERRIDE
    }
}
