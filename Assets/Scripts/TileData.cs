using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    private bool canBuildUpon;
    private bool blocksAir;
    private bool isSealed;

    public TileData()
    {
        canBuildUpon = false;
        blocksAir = false;
        isSealed = false;
    }

    public TileData(TileData oldData)
    {
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
}
