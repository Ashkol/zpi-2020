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
        DropTiles();
    }

    IEnumerator Drop(Tile tile, float time)
    {   
        yield return new WaitForSeconds(time);
        LeanTween.moveLocalY(tile.gameObject, 0, fallTime);
    }

    private void RiseAboveBoard()
    {
        foreach (var tile in tiles)
        {
            tile.transform.localPosition += Vector3.up * 10f;
            float localY = tile.natureHolder.localPosition.y;
            tile.natureHolder.localPosition -= Vector3.up * 10f;
            LeanTween.moveLocalY(tile.natureHolder.gameObject, localY, 1f).setDelay((tiles.Count * dropDelayTime + fallTime));

        }
    }

    private void DropTiles()
    {
        float time = 0f;
        foreach (var tile in tiles)
        {
            StartCoroutine(Drop(tile, time));
            time += dropDelayTime;
        }
    }
}
