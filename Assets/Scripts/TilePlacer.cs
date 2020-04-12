using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour
{
    private float clickReach = 3.0f;
    private Camera cam;

    private bool canPlace = false;

    public float breakTimer = 0.0f;

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
        Vector3 clickPosition;
        clickPosition = cam.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10.0f;

        // Detect input for selecting tool bar items
        DetectToolbarSelection();
        // Only display placement overlay if selected item is a placeable tile
        if (Toolbar.GetItemByIndex(Toolbar.currentIndex).itemType == InventoryItem.Type.Tile 
            && GridUtils.AABBFloat2D(0, StaticMaps.worldMap.size.x, 0, StaticMaps.worldMap.size.y, new Vector2(clickPosition.x, clickPosition.y)))
        {
            // Display placement preview
            StaticMaps.ToggleMapRenderer(StaticMaps.MapType.Placement, true);
            StaticMaps.placementMap.SetTile(Vector3Int.zero, Toolbar.GetItemByIndex(Toolbar.currentIndex).itemTile);
            DisplayTileToPlace();
        }
        else
        {
            StaticMaps.ToggleMapRenderer(StaticMaps.MapType.Placement, false);
        }
        DetectClick();
    }

    // Track mouse cursor with placement tile preview
    private void DisplayTileToPlace()
    {
        Vector3 clickPosition;
        clickPosition = cam.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10.0f;
        StaticMaps.placementTransform.position = new Vector3((int)clickPosition.x, (int)clickPosition.y, 0);

        if (clickPosition.x < StaticMaps.worldMap.size.x && clickPosition.y < StaticMaps.worldMap.size.y
            && clickPosition.x >= 0 && clickPosition.y >= 0)
        {
            if (StaticMaps.tileData[(int)clickPosition.x, (int)clickPosition.y].GetCanBuildUpon()
                && !StaticMaps.CheckMapPlayerIntersection(new Vector2Int((int)clickPosition.x, (int)clickPosition.y)))
            {
                canPlace = true;
                StaticMaps.placementMap.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
            }
            else
            {
                canPlace = false;
                StaticMaps.placementMap.color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
            }
        }
        else
        {
            canPlace = false;
        }
    }

    private void DetectClick()
    {
        // Get mouse position
        Vector3 clickPosition;
        clickPosition = cam.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10.0f;
        if (Input.GetMouseButton(0))
        {
            Vector3Int mapIndex = new Vector3Int((int)clickPosition.x, (int)clickPosition.y, 0);
            float dstToClick = (clickPosition - transform.position).magnitude;
            if (dstToClick <= clickReach && StaticMaps.worldMap.GetTile(mapIndex) != TileBook.GetTileByName("Space"))
            {
                breakTimer += Time.deltaTime;
                if (breakTimer >= 1.0f)
                {
                    StaticMaps.SetTile(StaticMaps.MapType.World, mapIndex, TileBook.GetTileByName("Space"));
                    breakTimer = 0.0f;
                    DetectSeal.CheckSeal();
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // If click detected check if within place range
            float dstToClick = (clickPosition - transform.position).magnitude;
            if (dstToClick <= clickReach && canPlace && Toolbar.GetItemByIndex(Toolbar.currentIndex).itemTile != null)
            {
                // Set tile at index to current tile
                Vector3Int mapIndex = new Vector3Int((int)clickPosition.x, (int)clickPosition.y, 0);
                StaticMaps.SetTile(StaticMaps.MapType.World, mapIndex, Toolbar.GetItemByIndex(Toolbar.currentIndex).itemTile);
                DetectSeal.CheckSeal();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            breakTimer = 0.0f;
        }

        StaticMaps.breakTimer = breakTimer;
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
