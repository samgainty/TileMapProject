using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class StaticMaps
{
    public enum MapType { World, Object, Placement};

    // Tile maps for each layer
    public static Tilemap worldMap;
    public static Tilemap objectMap;
    public static Tilemap placementMap;

    public static TileData[,] worldTileData;
    public static TileData[,] objectTileData;

    // Tile map renderers for each layer
    private static TilemapRenderer worldMapRenderer;
    private static TilemapRenderer objectMapRenderer;
    private static TilemapRenderer placementMapRenderer;

    public static Transform placementTransform;

    public static Vector2Int playerMapIndex;

    public static float breakTimer;

    public static void DetectMapRenderers()
    {
        // Get tile map renderers for each map layer if it exists
        if (worldMap != null)
            worldMapRenderer = worldMap.gameObject.GetComponent<TilemapRenderer>();
        if (objectMap != null)
            objectMapRenderer = objectMap.gameObject.GetComponent<TilemapRenderer>();
        if (placementMap != null)
            placementMapRenderer = placementMap.gameObject.GetComponent<TilemapRenderer>();
    }

    public static void ToggleMapRenderer(MapType mapType, bool state)
    {
        // Toggle renderer for the selected map layer
        switch (mapType)
        {
            case MapType.World:
                worldMapRenderer.enabled = state;
                break;
            case MapType.Object:
                objectMapRenderer.enabled = state;
                break;
            case MapType.Placement:
                placementMapRenderer.enabled = state;
                break;
        }
    }

    public static void SetTile(MapType mapType, Vector3Int position, Tile tile)
    {
        switch (mapType)
        {
            case MapType.World:
                worldMap.SetTile(position, tile);
                worldTileData[position.x, position.y] = new TileData(TileBook.GetTileDataByName(tile.name));
                break;
            case MapType.Object:
                objectMap.SetTile(position, tile);
                objectTileData[position.x, position.y] = new TileData(TileBook.GetTileDataByName(tile.name));
                break;
            case MapType.Placement:
                placementMap.SetTile(position, tile);
                break;
        }
    }

    public static bool CheckIfCanBuildUpon(int xPos, int yPos)
    {
        if (StaticMaps.worldTileData[xPos, yPos].GetCanBuildUpon() && StaticMaps.objectTileData[xPos, yPos].GetCanBuildUpon())
        {
            return true;
        }
        return false;
    }

    // Check if player position on map is same as tile position
    public static bool CheckMapPlayerIntersection(Vector2Int tilePosition)
    {
        if (playerMapIndex == tilePosition)
        {
            return true;
        }
        return false;
    }
}
