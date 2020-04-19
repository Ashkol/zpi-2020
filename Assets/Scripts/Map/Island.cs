using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public List<Tile> tiles;

    void Awake()
    {
        tiles = new List<Tile>(GetComponentsInChildren<Tile>());
    }
}
