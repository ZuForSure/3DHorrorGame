using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableJumpscare : MyMonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected float timer = 1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (this.anim != null) return;
        this.anim = GameObject.Find("Jumpscare Dr").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        StartCoroutine(this.DisableByAnimator());
    }

    private IEnumerator DisableByAnimator()
    {
        this.anim.SetTrigger("isDisable");
        AudioManager.Instance.PlayAudioClip("Jumpscare");

        yield return new WaitForSeconds(this.timer);
        transform.parent.gameObject.SetActive(false);
    }
}
