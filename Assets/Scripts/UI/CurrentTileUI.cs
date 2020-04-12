using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTileUI : MonoBehaviour
{
    public Text[] toolBarText;

    private void Update()
    {
        // Check if toolbar exists and has been initialised
        if (Toolbar.isInit())
        {
            // Iterate over toolbar array and display item names
            for (int i = 0; i < 10; i++)
            {
                if (Toolbar.GetItemByIndex(i).itemName != "")
                    toolBarText[i].text = (Toolbar.currentIndex == i) ? "[ " + Toolbar.GetItemByIndex(i).itemName + " ]" : Toolbar.GetItemByIndex(i).itemName;
                else
                    toolBarText[i].text = (Toolbar.currentIndex == i) ? "[ ---- ]" : "----";
            }
        }
    }
}
