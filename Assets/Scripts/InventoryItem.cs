using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InventoryItem
{
    public enum Type {Blank, Tile, Tool};

    public Type itemType;


    public string itemName;
    public int itemCount;

    public Tile itemTile;

    // Inventory Item constructor individual parameters
    public InventoryItem(Type type, string name, int count, Tile tile = null)
    {
        itemType = type;
        itemName = name;
        itemCount = count;
        itemTile = tile;
    }

    // Inventory item from tile
    public InventoryItem(Tile tile, int count)
    {
        itemType = Type.Tile;
        itemName = tile.name;
        itemCount = count;
        itemTile = tile;
    }

    // Default constructor
    public InventoryItem()
    {
        itemType = Type.Blank;
        itemName = "";
        itemCount = 0;
        itemTile = null;
    }
}
