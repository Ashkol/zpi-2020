using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storehouse : DistributionBuilding
{
    // Adds resources to player's resources pool
    public new void AddResourcess(Resources newResources)
    {
        BuildManager.instance.playerResources += newResources;
    }
}
