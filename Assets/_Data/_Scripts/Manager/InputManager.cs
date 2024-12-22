using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MyMonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected bool isClick;
    public bool IsClick => isClick;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 InputManager are allowed");
        InputManager.instance = this;
    }

    protected override void Update()
    {
        base.Update();
        this.GetMouseClick();
    }

    protected virtual void GetMouseClick()
    {
        this.isClick = Input.GetMouseButtonDown(0);
    }
}
