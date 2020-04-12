using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakLoadingBar : MonoBehaviour
{
    public Image loadBar;

    private void Update()
    {
        loadBar.fillAmount = StaticMaps.breakTimer;
    }
}
