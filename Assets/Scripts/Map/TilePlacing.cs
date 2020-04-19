using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacing : MonoBehaviour
{
    public int x, y, z;
    
    public float tileRadius;
    static float sqrt3 = Mathf.Sqrt(3f);

    void OnValidate()
    {

    }

    /// <summary>
    /// Each time the sum of x, y and z coordinates equals 0 the tile is placed in corresponding place
    /// </summary>
    public void PlaceTile()
    {
        Vector3 NEVector = (new Vector3(sqrt3, 0, 1)).normalized * tileRadius * sqrt3;
        Vector3 SEVector = (new Vector3(sqrt3, 0, -1)).normalized * tileRadius * sqrt3;

        if (x + y + z == 0)
        {
            gameObject.name = $"Tile [{x}, {y}, {z}]";

            Vector3 position = x * NEVector + y * SEVector;
            transform.position = position;
        }
    }
}
