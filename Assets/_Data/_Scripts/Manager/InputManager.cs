using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MyMonoBehaviour
{
    protected static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected bool isClick;
    [SerializeField] protected bool f_input;
    [SerializeField] protected bool tabInput;
    [SerializeField] protected bool eInput;
    public bool IsClick => isClick;
    public bool F_input => f_input;
    public bool TabInput => tabInput;
    public bool EInput => eInput;

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
        this.GetFClick();
        this.GetTabDown();
        this.GetEDown();
    }

    protected virtual void GetMouseClick()
    {
        this.isClick = Input.GetMouseButtonDown(0);
    }

    protected virtual void GetFClick()
    {
        this.f_input = Input.GetKeyDown(KeyCode.F);
    }

    protected virtual void GetTabDown()
    {
        this.tabInput = Input.GetKeyDown(KeyCode.Tab);
    }

    protected virtual void GetEDown()
    {
        this.eInput = Input.GetKeyDown(KeyCode.E);
    }
}
