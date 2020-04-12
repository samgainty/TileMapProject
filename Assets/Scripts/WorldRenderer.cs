using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldRenderer : MonoBehaviour
{
    WorldGrid grid;

    public Tile blankTile;

    // Tile map layers
    public Tilemap worldMap;
    public Tilemap objectMap;
    public Tilemap placementMap;

    private void Start()
    {
        // Get world grid object and get stored size
        grid = GameObject.FindObjectOfType<WorldGrid>();
        Vector3Int mapSize = new Vector3Int(grid.width, grid.height, 1);

        // Set tile map sizes to match world grid
        worldMap.size = mapSize;
        objectMap.size = mapSize;
        // Placement map will display a single tile preview therefore is of size 1
        placementMap.size = new Vector3Int(1, 1, 1);

        // Initialise static tile maps
        StaticMaps.worldMap = worldMap;
        StaticMaps.objectMap = objectMap;
        StaticMaps.placementMap = placementMap;

        // Detect and initialise static tile map renderers
        StaticMaps.DetectMapRenderers();

        // Set placement map transform for moving tile placement preview
        StaticMaps.placementTransform = placementMap.gameObject.transform;

        StaticMaps.tileData = new TileData[grid.width, grid.height];
        for (int y = 0; y < grid.height; y++)
        {
            for (int x = 0; x < grid.width; x++)
            {
                StaticMaps.tileData[x, y] = new TileData();
            }
        }

        Debug.Log("Tile Count: " + TileBook.GetTileCount());
        SetGridToSpace();
        CreateStartRoom();
    }

    // Initialise whole grid to space tiles
    public void SetGridToSpace()
    {
        for (int y = 0; y < grid.height; y++)
        {
            for (int x = 0; x < grid.width; x++)
            {
                StaticMaps.SetTile(StaticMaps.MapType.World, new Vector3Int(x, y, 0), TileBook.GetTileByName("Space"));
            }
        }
    }

    // Create debug room
    private void CreateStartRoom()
    {
        for (int y = 4; y < 10; y++)
        {
            for (int x = 4; x < 10; x++)
            {
                StaticMaps.SetTile(StaticMaps.MapType.World, new Vector3Int(x, y, 0), TileBook.GetTileByName("Wall"));
            }
        }
        for (int y = 5; y < 9; y++)
        {
            for (int x = 5; x < 9; x++)
            {
                StaticMaps.SetTile(StaticMaps.MapType.World, new Vector3Int(x, y, 0), TileBook.GetTileByName("Floor"));
            }
        }
    }
}
