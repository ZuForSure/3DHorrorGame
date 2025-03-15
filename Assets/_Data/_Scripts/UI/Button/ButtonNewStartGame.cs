using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNewStartGame : ButtonNewGame
{
    [Header("New Start Game")]
    [SerializeField] protected GameObject directionText;

    protected override void Start()
    {
        base.Start();
        this.directionText.SetActive(false);
    }

    protected override void OnClick()
    {
        this.directionText.SetActive(true);

        StartCoroutine(this.LoadMainGame());
    }

    protected IEnumerator LoadMainGame()
    {
        yield return new WaitForSeconds(3);

        this.animCtrlTrans.SetTrigger("transEnd");
        SceneManager.LoadSceneAsync("MainGame");
    }
}
