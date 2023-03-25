using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public int cellSize = -1;
    private Tile[,] tiles;

    // 해당 코드가 호출될 함수를 작성하여야합니다. 이 함수는 MapGenerator에서 호출될 예정입니다.
    public void InitTileCells()
    {
        if (cellSize == -1)
            return;

        tiles = new Tile[cellSize, cellSize];

        for (int row = 0; row < cellSize; row++)
        {
            for (int col = 0; col < cellSize; col++)
            {
                Tile tile = UtillHelper.Find<Tile>(transform, "Row"+row.ToString()+"/"+"Col"+col.ToString());
                if(tile != null)
                {
                    bool isWalkable = true;
                    if (tile.gameObject.tag == "NotWalkable")
                        isWalkable = false;
                    tile.Init(row, col, isWalkable);
                }    
            }
        }
    }

}
