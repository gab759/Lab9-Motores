using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorProperty : ColorProperty
{
    private void OnEnable()
    {
        ColorPowerUpManager.OnChangeColor += SetUpColor;
    }

    private void OnDisable()
    {
        ColorPowerUpManager.OnChangeColor -= SetUpColor;
    }
}