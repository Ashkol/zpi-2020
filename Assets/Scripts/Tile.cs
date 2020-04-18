using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    // Holders for building and nature objects, so they can be placed in right place from the script
    public Transform buildingHolder;
    [SerializeField] Building building;
    public Building Building
    {
        get
        {
            return building;
        }
        set
        {
            if (building == null)
            {
                building = value;
            }
        }
    }
    public Transform natureHolder;
    [SerializeField] GameObject natureObject;
    [Tooltip("Type of the tile, more info about tile types in GDD")]
    public TileType tileType;
    List<Tile> neighbours = new List<Tile>();

    public enum TileType
    {
        Regular,
        Forest,
        Rocks,
        Water
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Here Build Manager methods may be handled, ex. if the tile is clicked when the building mode is active -> build building here
        //BuildPanel.instance.gameObject.SetActive(true);
        BuildManager.instance.BuildModeOn = true;
        BuildManager.instance.SetBuildingToBuild(-1);
        BuildManager.instance.tileToBuildOn = this;
        BuildPanel.instance.Show(this);
    }

    void Start()
    {
        Island island = transform.parent.gameObject.GetComponent<Island>();

        foreach (Tile tile in island.tiles)
        {
            if (gameObject != tile.gameObject && isNeigbour(tile)) {
                neighbours.Add(tile);
            }
        }
    }

    private bool isNeigbour(Tile tile)
    {
        TilePlacing siblingCoords = tile.GetComponent<TilePlacing>();
        TilePlacing coords = gameObject.GetComponent<TilePlacing>();

        return
            !isOpposite(coords, siblingCoords) &&
            (isAdjacent(coords.x, siblingCoords.x) ||
            isAdjacent(coords.y, siblingCoords.y) ||
            isAdjacent(coords.z, siblingCoords.z));
    }

    private bool isAdjacent(int coord1, int coord2)
    {
        return coord1 == coord2;
    }

    private bool isOpposite(TilePlacing coords, TilePlacing siblingCoords)
    {
        return
            coords.x + siblingCoords.x == 0 &&
            coords.y + siblingCoords.y == 0 &&
            coords.z + siblingCoords.z == 0;
    }
}
