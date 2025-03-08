using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSceneWin : MyMonoBehaviour
{
    [SerializeField] protected GameObject winGame;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWinGame();
    }

    protected override void Start()
    {
        base.Start();
        this.winGame.SetActive(false);
    }

    protected virtual void LoadWinGame()
    {
        if (this.winGame != null) return;
        this.winGame = GameObject.Find("Win Game");
        Debug.Log(transform.name + ": LoadWinGame", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.winGame.SetActive(true);
    }
}
