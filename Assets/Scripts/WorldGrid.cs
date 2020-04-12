using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    Grid grid;

    // Grid global attributes
    public int width = 100;
    public int height = 100;

    public float cellSize = 1.0f;

    public bool debugGrid = false;

    private void Start()
    {
        grid = new Grid(width, height, cellSize);
    }
}
