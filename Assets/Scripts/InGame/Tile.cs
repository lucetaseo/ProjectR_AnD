using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int row = -1;
    public int col = -1;
    public bool isWalkable = true;
    public List<Tile> adjacentTiles = new List<Tile>();

    //타일의 값을 초기화해줄 함수입니다.
    public void Init(int row, int col, bool isWalkable)
    {
        this.row = row;
        this.col = col;
        this.isWalkable = isWalkable;
    }

    public void CalculateAdjacentTiles()
    {
        adjacentTiles.Clear();
        CellManager cellManager = GetComponentInParent<CellManager>();
        // 현재 타일의 위, 아래, 왼쪽, 오른쪽 타일을 가져옵니다.
        Tile upTile = cellManager.GetTile(row - 1, col);
        Tile downTile = cellManager.GetTile(row + 1, col);
        Tile leftTile = cellManager.GetTile(row, col - 1);
        Tile rightTile = cellManager.GetTile(row, col + 1);

        // 각 타일이 null이 아니면 adjacentTiles 리스트에 추가합니다.
        if (upTile != null)
            adjacentTiles.Add(upTile);
        if (downTile != null)
            adjacentTiles.Add(downTile);
        if (leftTile != null)
            adjacentTiles.Add(leftTile);
        if (rightTile != null)
            adjacentTiles.Add(rightTile);
    }
}
