using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Tile tile;
    public Tile.TileType tileType;

    [Header("Surrounding")]
    [SerializeField] private Transform entrance;
    public Transform Entrance { private set { entrance = value; }  get { return entrance; } }

    [Header("Info")]
    public Sprite icon;
    public BuildingDescription description;
    public Resources buildResources;
    [SerializeField] BuildingPanel buildingPanel;

    void Start()
    {
        foreach(Building neighbour in GetNeighbouringBuildings<Building>())
        {
            neighbour.CheckForNeighbouringBuildings();
        }
    }

    public List<T> GetNeighbouringBuildings<T>()
    {
        List<T> buildings = new List<T>();
        foreach (Tile tile in tile.neighbours)
        {
            if (tile.Building != null)
            {
                if (tile.Building.TryGetComponent(out T building))
                {
                    buildings.Add(building);
                }
            }
           
        }
        return buildings;
    }

    // Checks to see if any building required for functioning is adjacent to this one
    public virtual bool CheckForNeighbouringBuildings()
    {
        Debug.Log("Checks not really");
        return false;
    }
}
