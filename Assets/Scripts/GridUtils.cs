using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridUtils
{
    public static bool AABBInt2D(int minX, int maxX, int minY, int maxY, Vector2Int position)
    {
        if (position.x >= minX && position.x <= maxX)
        {
            if (position.y >= minY && position.y <= maxY)
            {
                return true;
            }
        }
        return false;
    }

    public static bool AABBFloat2D(float minX, float maxX, float minY, float maxY, Vector2 position)
    {
        if (position.x >= minX && position.x <= maxX)
        {
            if (position.y >= minY && position.y <= maxY)
            {
                return true;
            }
        }
        return false;
    }
}
