using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrAnAttack : MyMonoBehaviour
{
    [SerializeField] protected Animator drAnAnim;
    [SerializeField] protected DrAnMovement movement;
    [SerializeField] protected FirstPersonMovement playerMovement;
    [SerializeField] protected GameObject playerCam;
    [SerializeField] protected GameObject gameOver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnim();
        this.LoadGameOver();
        this.LoadFirstPersonMovement();
    }

    protected virtual void LoadAnim()
    {
        if (this.drAnAnim != null) return;
        this.drAnAnim = transform.parent.GetComponent<Animator>();
        this.movement = transform.parent.GetComponent<DrAnMovement>();
        Debug.Log(transform.name + ": LoadAnim", gameObject);
    }
    
    protected virtual void LoadFirstPersonMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = GameObject.Find("Player Controller").GetComponent<FirstPersonMovement>();
        Debug.Log(transform.name + ": LoadFirstPersonMovement", gameObject);
    }

    protected virtual void LoadGameOver()
    {
        if (this.gameOver != null) return;
        this.gameOver = GameObject.Find("Game Over");
        Debug.Log(transform.name + ": LoadGameOver", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        Destroy(this.movement);
        Destroy(this.playerCam.GetComponent<FirstPersonLook>());

        this.playerMovement.speed = 0;
        this.playerCam.transform.LookAt(transform);
        this.drAnAnim.SetTrigger("isAttack");

        AudioManager.Instance.PlayAudioClip("BeCatched");

        StartCoroutine(this.Reload());
    }

    protected IEnumerator Reload()
    {
        yield return new WaitForSeconds(5);

        Cursor.lockState = CursorLockMode.None;
        this.gameOver.SetActive(true);

        //this.drAnAnim.SetTrigger("isIdle");
        //GameManager.Instance.ReloadWhenGameOver();
    }
}
