using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DetectSeal
{ 
    public static void CheckSeal()
    {
        // Set all points on map to sealed
        for (int y = 0; y < StaticMaps.worldMap.size.y; y++)
        {
            for (int x = 0; x < StaticMaps.worldMap.size.x; x++)
            {
                StaticMaps.tileData[x, y].SetIsSealed(true);
            }
        }

        // Iterate over all space tiles and flood fill to find connected tiles
        for (int y = 0; y < StaticMaps.worldMap.size.y; y++)
        {
            for (int x = 0; x < StaticMaps.worldMap.size.x; x++)
            {
                if (StaticMaps.worldMap.GetTile(new Vector3Int(x, y, 0)).name == "Space")
                {
                    FloodFill(new Vector2Int(x,y));
                }
            }
        }
    }

    public static void FloodFill(Vector2Int q)
    {
        // Get grid dimensions
        int w = StaticMaps.worldMap.size.x;
        int h = StaticMaps.worldMap.size.y;

        // Bounds check
        if (q.y < 0 || q.y > h - 1 || q.x < 0 || q.y > w - 1)
            return;

        // Create work stack
        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        stack.Push(q);

        while (stack.Count > 0)
        {
            // Take current work tile
            Vector2Int p = stack.Pop();
            int x = p.x;
            int y = p.y;
            // Bounds check
            if (y < 0 || y > h - 1 || x < 0 || x > w - 1)
                continue;
            // If tile can block airflow then move onto next tile
            if (StaticMaps.tileData[x, y].CanBlockAir())
                continue;

            // If tile has not already been checked the set sealed to false
            if (StaticMaps.tileData[x, y].IsSealed())
            {
                StaticMaps.tileData[x, y].SetIsSealed(false);
                // Add adjacent tiles to work queue
                stack.Push(new Vector2Int(x + 1, y));
                stack.Push(new Vector2Int(x - 1, y));
                stack.Push(new Vector2Int(x, y + 1));
                stack.Push(new Vector2Int(x, y - 1));
            }
        }
    }
}
