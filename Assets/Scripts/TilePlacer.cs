using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour
{
    private float clickReach = 3.0f;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        Toolbar.InitToolBar(10);

        // Fill toolbar with debug items
        for (int i = 0; i < TileBook.GetTileCount(); i++)
        {
            Toolbar.SetItemAtIndex(new InventoryItem(TileBook.GetTileByIndex(i), 1), i);
        }
    }

    void Update()
    {
        // Detect input for selecting tool bar items
        DetectToolbarSelection();
        // Only display placement overlay if selected item is a placeable tile
        if (Toolbar.GetItemByIndex(Toolbar.currentIndex).itemType == InventoryItem.Type.Tile)
        {
            // Display placement preview
            StaticMaps.ToggleMapRenderer(StaticMaps.MapType.Placement, true);
            StaticMaps.placementMap.SetTile(Vector3Int.zero, Toolbar.GetItemByIndex(Toolbar.currentIndex).itemTile);
            DisplayTileToPlace();
            DetectClick();
        }
        else
        {
            StaticMaps.ToggleMapRenderer(StaticMaps.MapType.Placement, false);
        }
    }

    // Track mouse cursor with placement tile preview
    private void DisplayTileToPlace()
    {
        Vector3 clickPosition;
        clickPosition = cam.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10.0f;
        StaticMaps.placementTransform.position = new Vector3((int)clickPosition.x, (int)clickPosition.y, 0);
    }

    private void DetectClick()
    {
        // Get mouse position
        Vector3 clickPosition;
        clickPosition = cam.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10.0f;
        if (Input.GetMouseButtonDown(0))
        {
            // If click detected check if within place range
            float dstToClick = (clickPosition - transform.position).magnitude;
            if (dstToClick <= clickReach)
            {
                Debug.Log(clickPosition);
                // Set tile at index to current tile
                Vector3Int mapIndex = new Vector3Int((int)clickPosition.x, (int)clickPosition.y, 0);
                //map.SetTile(mapIndex, TileBook.GetTileByName("Blank"));
            }
        }
    }

    private void DetectToolbarSelection()
    {
        // Detect key press for numbers 1-9 and 0
        for (int i = 0; i <= 9; i++)
        {
            // Set current toolbar index to appropriate key press value
            if (Input.GetKeyDown(i.ToString()))
            {
                // If key was 0 this corresponds to array index 9
                if (i == 0)
                    Toolbar.currentIndex = 9;
                else
                    Toolbar.currentIndex = i - 1;
            }
        }
    }
}
