using UnityEngine;

public class FlashLight : MyMonoBehaviour
{
    [SerializeField] protected GameObject flashLight;
    [SerializeField] protected GameObject flashLightObj;
    [SerializeField] protected bool on, off;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFlashLight();
    }

    protected override void Start()
    {
        base.Start();
        this.on = false;
        this.off = true;
        this.flashLight.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();
        if (!this.HaveFlashLight()) return;

        this.ToggleFlashLight();
    }

    protected virtual void LoadFlashLight()
    {
        if (this.flashLight != null) return;
        this.flashLight = GameObject.Find("Flash Light");
        this.flashLightObj = GameObject.Find("Flashlight Obj");
        Debug.Log(transform.name + ": LoadFlashLight", gameObject);
    }

    protected virtual bool HaveFlashLight()
    {
        if(Inventory.Instance.FindItem(this.flashLightObj.transform.name) == null) return false;
        return true;
    }

    protected virtual void ToggleFlashLight()
    {
        if(this.on && InputManager.Instance.F_input)
        {
            this.flashLight.SetActive(false);
            this.on = false;
            this.off = true;
            AudioManager.Instance.PlayAudioClip("Flashlight");
        } 
        else if(this.off && InputManager.Instance.F_input)
        {
            this.flashLight.SetActive(true);
            this.on = true;
            this.off = false;
            AudioManager.Instance.PlayAudioClip("Flashlight");
        }
    }
}
