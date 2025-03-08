using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerWinGame : MyMonoBehaviour
{
    protected static TriggerWinGame instance;
    public static TriggerWinGame Instance => instance;

    [SerializeField] protected GameObject player;
    [SerializeField] protected Animator animCtrlTrans;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 TriggerWinGame allowed");
        TriggerWinGame.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
        this.LoadAnimCtrl();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player Controller");
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    protected virtual void LoadAnimCtrl()
    {
        if (this.animCtrlTrans != null) return;
        this.animCtrlTrans = GameObject.Find("Transition").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimCtrl", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        //FirstPersonMovement movement = this.player.GetComponent<FirstPersonMovement>();
        //movement.speed = 0;

        StartCoroutine(this.LoadSceneWithTransition());
    }

    protected IEnumerator LoadSceneWithTransition()
    {
        Cursor.lockState = CursorLockMode.None;
        this.animCtrlTrans.SetTrigger("transEnd");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("WinGame");
        this.animCtrlTrans.SetTrigger("transStr");
    }
}
