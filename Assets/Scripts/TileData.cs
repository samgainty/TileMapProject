using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    public enum TileType { Blank, WorldTile, ObjectTile };

    private TileType tileType;
    private bool canBuildUpon;
    private bool blocksAir;
    private bool isSealed;

    public TileData()
    {
        tileType = TileType.Blank;
        canBuildUpon = true;
        blocksAir = false;
        isSealed = false;
    }

    public TileData(TileData oldData)
    {
        tileType = oldData.tileType;
        canBuildUpon = oldData.canBuildUpon;
        blocksAir = oldData.blocksAir;
        isSealed = oldData.isSealed;
    }

    public bool GetCanBuildUpon() { return canBuildUpon; }
    public void SetCanBuildUpon(bool canBuild) { canBuildUpon = canBuild; }

    public bool CanBlockAir() { return blocksAir; }
    public void SetCanBlockAir(bool canBlock) { blocksAir = canBlock; }

    public bool IsSealed() { return isSealed; }
    public void SetIsSealed(bool seal) { isSealed = seal; }

    public TileType GetTileType() { return tileType; }
    public void SetTileType(TileType tileT) { tileType = tileT; }
}
