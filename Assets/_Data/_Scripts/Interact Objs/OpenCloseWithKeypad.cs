using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavKeypad 
{

    public class OpenCloseWithKeypad : OpenCloseAble
    {
        [Header("With Key Pad")]
        [SerializeField] protected Keypad keyPad;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadKeyPad();
        }

        protected virtual void LoadKeyPad()
        {
            if (this.keyPad != null) return;
            this.keyPad = GameObject.Find("Keypad").GetComponent<Keypad>();
            Debug.Log(transform.name + ": LoadKeyPad", gameObject);
        }

        public override void Open()
        {
            if (!this.keyPad.AccessWasGranted) return;

            base.Open();
        }

        public override void Close()
        {
            return;
        }
    }
}
