using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGuideFlashLight : ShowGuide
{
    private void OnDisable()
    {
        this.ShowGuideText();
    }
}
