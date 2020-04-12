using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Toolbar
{
    private static InventoryItem[] bar;
    public static int currentIndex = 0;

    public static bool isInit()
    {
        return (bar != null);
    }

    // Get inventory item by index
    public static InventoryItem GetItemByIndex(int index)
    {
        return bar[index];
    }

    // Set an inventory item at index
    public static void SetItemAtIndex(InventoryItem item, int index)
    {
        bar[index] = item;
    }

    // Initialise toolbar array and fill with empty inventory items
    public static void InitToolBar(int size)
    {
        bar = new InventoryItem[size];
        for (int i = 0; i < size; i++)
        {
            bar[i] = new InventoryItem();
        }
    }
}
