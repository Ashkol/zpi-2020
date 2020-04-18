using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public List<Building> buildingPrefabs;
    //public bool buildModeOn = false;
    public bool BuildModeOn { get; set; }
    Building buildingToBuild;
    public Tile tileToBuildOn;

    void Awake()
    {
        instance = this;
    }

    public void SetBuildingToBuild(int i)
    {
        if (i >= 0 && i < buildingPrefabs.Count)
        {
            buildingToBuild = buildingPrefabs[i];
        }
        else
        {
            buildingToBuild = null;
        }
    }

    public void SetBuildingToBuild(Building building)
    {
        buildingToBuild = building;
    }

    public bool Build(Tile tile)
    {
        if (tile.Building == null && buildingToBuild != null && tile.tileType == buildingToBuild.tileType)
        {
            Building newBuilding = Instantiate(buildingToBuild, tile.buildingHolder);
            tile.Building = newBuilding;
            newBuilding.tile = tile;
            return true;
        }
        return false;
    }

    public void Build()
    {
        if (Build(tileToBuildOn))
            //BuildPanel.instance.gameObject.SetActive(false);
            BuildPanel.instance.Hide();
    }

    public void Raze()
    {
        if (tileToBuildOn.Building != null)
        {
            Destroy(tileToBuildOn.Building.gameObject);
            //BuildPanel.instance.gameObject.SetActive(false);
            BuildPanel.instance.Hide();
        }
    }
}
