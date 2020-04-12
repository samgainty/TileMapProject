using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMetrics : MonoBehaviour
{
    public WorldGrid grid;
    
    public enum Metric { Default, BuildBlocked, AirSealed};

    public Metric metric;

    private void OnDrawGizmos()
    {
        if (StaticMaps.tileData != null)
        {
            switch (metric)
            {
                case Metric.Default:
                    DrawGridClear();
                    break;
                case Metric.BuildBlocked:
                    DrawGridBuildingBlocked();
                    break;
                case Metric.AirSealed:
                    DrawGridAirSealed();
                    break;
            }
        }
    }

    private void DrawGridClear()
    {
        // Iterate over XY dimensions
        for (int y = 0; y < grid.height; y++)
        {
            for (int x = 0; x < grid.width; x++)
            {
                // Draw default wire grid
                CustomGizmos.DrawWireSquare(GetWorldPosition(x, y) + new Vector3(0.5f, 0.5f, 0.0f), Vector3.one * grid.cellSize, Color.white, Color.clear, "");
            }
        }
    }

    private void DrawGridBuildingBlocked()
    {
        // Iterate over XY dimensions
        for (int y = 0; y < grid.height; y++)
        {
            for (int x = 0; x < grid.width; x++)
            {
                // Draw grid indicating tiles which cannot be built upon
                if (StaticMaps.tileData[x,y].GetCanBuildUpon())
                CustomGizmos.DrawWireSquare(GetWorldPosition(x, y) + new Vector3(0.5f, 0.5f, 0.0f), Vector3.one * grid.cellSize, Color.white, Color.clear, "");
                else
                    CustomGizmos.DrawWireSquare(GetWorldPosition(x, y) + new Vector3(0.5f, 0.5f, 0.0f), Vector3.one * grid.cellSize, Color.white, new Color(0.75f, 0.0f, 0.0f, 0.4f), "");
            }
        }
    }

    private void DrawGridAirSealed()
    {
        // Iterate over XY dimensions
        for (int y = 0; y < grid.height; y++)
        {
            for (int x = 0; x < grid.width; x++)
            {
                // Draw grid indicating air sealed spaces
                if (StaticMaps.tileData[x, y].IsSealed())
                    CustomGizmos.DrawWireSquare(GetWorldPosition(x, y) + new Vector3(0.5f, 0.5f, 0.0f), Vector3.one * grid.cellSize, Color.white, new Color(0.0f, 0.0f, 0.75f, 0.4f), "");
                else
                    CustomGizmos.DrawWireSquare(GetWorldPosition(x, y) + new Vector3(0.5f, 0.5f, 0.0f), Vector3.one * grid.cellSize, Color.white, Color.clear, "");
            }
        }
    }

    // Translate grid index to world position
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * grid.cellSize;
    }
}
