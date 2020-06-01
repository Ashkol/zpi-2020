﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [Header("Building")]
    public static BuildManager instance;
    public List<Building> buildingPrefabs;
    public Island island, sea;
    public bool BuildModeOn { get; set; }
    Building buildingToBuild;
    public Tile tileToBuildOn;
    [Header("Resources")]
    public Resources playerResources;

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
        if (building != buildingToBuild)
        {
            buildingToBuild = building;
            island.DropTiles((Tile tile) => tile.tileType != buildingToBuild.tileType && tile.Rised);
            island.RiseTilesAboveBoard((Tile tile) => tile.tileType == buildingToBuild.tileType && tile.Building == null && !tile.Rised);
        }
    }

    public bool Build(Tile tile)
    {
        if (tile.Building == null && buildingToBuild != null && tile.tileType == buildingToBuild.tileType)
        {
            if (playerResources >= buildingToBuild.buildResources)
            {
                PlayBuildingSound();
                playerResources -= buildingToBuild.buildResources;
                Building newBuilding = Instantiate(buildingToBuild, tile.buildingHolder);
                tile.Building = newBuilding;
                newBuilding.tile = tile;
                BuildModeOn = false;
                island.DropTiles((Tile t) => true);
                return true;
            }

        }
        BuildModeOn = false;
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

    private void PlayBuildingSound()
    {
        var sfxPlayer = GameObject.Find("Building SFX");
        if (sfxPlayer != null)
        {
            var audio = sfxPlayer.GetComponent<AudioSource>();
            if (audio != null)
                audio.Play();
        }

    }
}
