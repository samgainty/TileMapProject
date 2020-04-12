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

    // Tile map renderers for each layer
    private static TilemapRenderer worldMapRenderer;
    private static TilemapRenderer objectMapRenderer;
    private static TilemapRenderer placementMapRenderer;

    public static Transform placementTransform;

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
}
