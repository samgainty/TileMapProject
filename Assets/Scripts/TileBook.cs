using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TileBook
{
    // Tile and index dictionaries
    private static Dictionary<string, Tile> tiles;
    private static Dictionary<string, TileData> tileData;
    private static Dictionary<int, string> tileIndices;

    static TileBook()
    {
        // Load tile prefabs from folder
        Tile[] tilePrefabs = Resources.LoadAll<Tile>("Prefabs/Tiles");
        // Initialise dictionary for tiles and indices
        tiles = new Dictionary<string, Tile>(tilePrefabs.Length);
        tileIndices = new Dictionary<int, string>(tilePrefabs.Length);
        tileData = new Dictionary<string, TileData>(tilePrefabs.Length);

        int index = 0;
        // Fill dictionary for tile and indices from loaded resources
        foreach (Tile tile in tilePrefabs)
        {
            tiles.Add(tile.name, tile);
            tileIndices.Add(index, tile.name);

            TileData data = new TileData();
            bool canBuild = !(tile.name == "Wall" || tile.name == "Object");
            bool canBlock = (tile.name == "Wall");
            TileData.TileType type = (tile.name == "Object" || tile.name == "NullObject") ? TileData.TileType.ObjectTile : TileData.TileType.WorldTile;
            data.SetTileType(type);
            data.SetCanBuildUpon(canBuild);
            data.SetCanBlockAir(canBlock);
            data.SetIsSealed(false);

            tileData.Add(tile.name, data);

            index++;
        }
    }

    public static int GetTileCount()
    {
        return tiles.Count;
    }

    public static Tile GetTileByName(string name)
    {
        return tiles[name];
    }

    // Get tile by name gathered from index/name dictionary
    public static Tile GetTileByIndex(int index)
    {
        return tiles[tileIndices[index]];
    }

    public static TileData GetTileDataByName(string name)
    {
        return tileData[name];
    }

    public static TileData GetTileDataByIndex(int index)
    {
        return tileData[tileIndices[index]];
    }
}
