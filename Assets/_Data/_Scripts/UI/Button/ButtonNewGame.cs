using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNewGame : BaseButton
{
    [SerializeField] protected Animator animCtrlTrans;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimCtrl();
    }

    protected virtual void LoadAnimCtrl()
    {
        if (this.animCtrlTrans != null) return;
        this.animCtrlTrans = GameObject.Find("Transition").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimCtrl", gameObject);
    }

    protected override void OnClick()
    {
        this.animCtrlTrans.SetTrigger("transEnd");

        SceneManager.LoadSceneAsync("MainGame");
    }
}
