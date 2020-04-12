using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;

    private float cellSize;

    private int[,] gridArray;

    // Grid Constructor
    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
    }

    // Translate grid index to world position
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public void DrawGridCells(Color colour, float padding)
    {
        // Iterate over XY dimensions
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Drawm custom grid cell gizmo
                CustomGizmos.DrawWireSquare(GetWorldPosition(x,y) + new Vector3(0.5f, 0.5f, 0.0f), Vector3.one * cellSize, colour, Color.clear);
            }
        }      
    }
}
