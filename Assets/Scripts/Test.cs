using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool[,] aTiles;
    public bool[,] bTiles;
    public AdjacentDirection direction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //bool areAdjacentCellsWalkable = AreAdjacentCellsAllWalkable(aTiles, bTiles, direction);
            //Debug.Log($"Are adjacent cells walkable? {areAdjacentCellsWalkable}");
        }
    }
}
