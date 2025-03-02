using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MyMonoBehaviour
{
    protected static AudioManager instance;
    public static AudioManager Instance => instance;

    [SerializeField] protected AudioSource audioSoure;
    public List<AudioClip> audioClips;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSources();
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) Debug.LogWarning("Only 1 AudioManager are allowed");
        AudioManager.instance = this;
    }

    protected virtual void LoadAudioSources()
    {
        if (this.audioSoure != null) return;
        this.audioSoure = GameObject.Find("Interact Audio").GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadAudioSources", gameObject);
    }

    public virtual void PlayAudioClip(string clipName)
    {
        foreach(AudioClip clip in this.audioClips)
        {
            if (clip.name != clipName) continue;
            this.audioSoure.PlayOneShot(clip);
        }
    }
}
