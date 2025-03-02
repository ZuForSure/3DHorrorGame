using UnityEngine;

public class LightSwitch : MyMonoBehaviour
{
    [SerializeField] protected GameObject lamp;
    [SerializeField] protected GameObject pointLight;
    public bool on, off;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameObjectLight();
    }

    protected override void Start()
    {
        base.Start();
        this.pointLight.SetActive(false);
        this.on = false;
        this.off = true;
    }

    protected virtual void LoadGameObjectLight()
    {
        if (this.pointLight != null) return;
        this.lamp = transform.GetChild(0).gameObject;
        this.pointLight = this.lamp.transform.GetChild(0).gameObject;
        Debug.Log(transform.name + ": LoadGameObjectLight", gameObject);
    }

    public virtual void TurnOn()
    {
        this.pointLight.SetActive(true);
        this.on = true; 
        this.off = false;
        AudioManager.Instance.PlayAudioClip("Flashlight");
    }

    public virtual void TurnOff() 
    {
        this.pointLight.SetActive(false);
        this.off = true;
        this.on = false;
        AudioManager.Instance.PlayAudioClip("Flashlight");
    }
}
