using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Island : MonoBehaviour
{
    public List<Tile> tiles;

    private float fallTime = 0.3f;
    private float dropDelayTime = 0.1f;

    void Awake()
    {
        tiles = new List<Tile>(GetComponentsInChildren<Tile>());
        RiseAboveBoard();
        DropTiles(true);
    }

    public void RiseTilesAboveBoard(System.Func<Tile, bool> predicament)
    {
        float localY;
        foreach (Tile t in tiles)
        {
            if (predicament(t))
            {
                localY = t.transform.localPosition.y;
                LeanTween.moveLocalY(t.gameObject, 2f, 0.5f);
                t.Rised = true;
            }
        }
    }

    public void DropTiles(System.Func<Tile, bool> predicament)
    {
        foreach (var t in tiles)
        {
            if (predicament(t))
            {
                LeanTween.moveLocalY(t.gameObject, 0, fallTime);
                t.Rised = false;
            }
        }
    }

    IEnumerator Drop(Tile tile, float time)
    {   
        yield return new WaitForSeconds(time);
        LeanTween.moveLocalY(tile.gameObject, 0, fallTime);
        tile.Rised = false;
    }

    private void RiseAboveBoard()
    {
        foreach (var tile in tiles)
        {
            tile.transform.localPosition += Vector3.up * 10f;
            float localY = tile.natureHolder.localPosition.y;
            tile.natureHolder.localPosition -= Vector3.up * 10f;
            LeanTween.moveLocalY(tile.natureHolder.gameObject, localY, 1f).setDelay((tiles.Count * dropDelayTime + fallTime));
            tile.Rised = true;
        }
    }

    private void DropTiles(bool oneByOne = false)
    {
        float time = 0f;
        foreach (var tile in tiles)
        {
            if (!oneByOne)
                time = 0;
            if (tile.Rised)
                StartCoroutine(Drop(tile, time));
            time += dropDelayTime;
        }
    }
}
