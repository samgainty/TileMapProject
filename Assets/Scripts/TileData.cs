using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    private bool canBuildUpon;

    public bool GetCanBuildUpon()
    {
        return canBuildUpon;
    }

    public void SetCanBuildUpon(bool canBuild)
    {
        canBuildUpon = canBuild;
    }
}
