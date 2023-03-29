using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AdjacentDirection
{
    Right,
    Left,
    Up,
    Down
}

public class MapGenerator : MonoBehaviour
{
    // 만약 해당 값이 false값을 반환 했다면,
    //public List<bool[,]> GetAdjacentTiles(bool[,] tiles, AdjacentDirection direction)
    //{
    //    int rows = tiles.GetLength(0);
    //    int cols = tiles.GetLength(1);
    //    List<bool[,]> adjacentTiles = new List<bool[,]>();

    //    switch (direction)
    //    {
    //        case AdjacentDirection.Right:
    //            for (int row = 0; row < rows; row++)
    //            {
    //                bool[,] adjacentTile = new bool[rows, cols];
    //                for (int col = 0; col < cols - 1; col++)
    //                {
    //                    adjacentTile[row, col] = tiles[row, col + 1];
    //                }
    //                adjacentTile[row, cols - 1] = false;
    //                adjacentTiles.Add(adjacentTile);
    //            }
    //            break;

    //        case AdjacentDirection.Left:
    //            for (int row = 0; row < rows; row++)
    //            {
    //                bool[,] adjacentTile = new bool[rows, cols];
    //                adjacentTile[row, 0] = false;
    //                for (int col = 1; col < cols; col++)
    //                {
    //                    adjacentTile[row, col] = tiles[row, col - 1];
    //                }
    //                adjacentTiles.Add(adjacentTile);
    //            }
    //            break;

    //        case AdjacentDirection.Up:
    //            for (int col = 0; col < cols; col++)
    //            {
    //                bool[,] adjacentTile = new bool[rows, cols];
    //                adjacentTile[0, col] = false;
    //                for (int row = 1; row < rows; row++)
    //                {
    //                    adjacentTile[row, col] = tiles[row - 1, col];
    //                }
    //                adjacentTiles.Add(adjacentTile);
    //            }
    //            break;

    //        case AdjacentDirection.Down:
    //            for (int col = 0; col < cols; col++)
    //            {
    //                bool[,] adjacentTile = new bool[rows, cols];
    //                for (int row = 0; row < rows - 1; row++)
    //                {
    //                    adjacentTile[row, col] = tiles[row + 1, col];
    //                }
    //                adjacentTile[rows - 1, col] = false;
    //                adjacentTiles.Add(adjacentTile);
    //            }
    //            break;
    //    }

    //    return adjacentTiles;
    //}

    public int[,] GenerateMap(int mapSize, int maxCell, GameObject[] cellPrefabs)
    {
        int[,] map = new int[mapSize, mapSize];

        // 첫번째 셀 랜덤 배치
        int x = Random.Range(0, mapSize);
        int y = Random.Range(0, mapSize);
        map[x, y] = 1;
        int cellCount = 1;

        // 셀 랜덤 배치
        while (cellCount < maxCell)
        {
            int randX = Random.Range(0, mapSize);
            int randY = Random.Range(0, mapSize);

            if (map[randX, randY] == 0 && IsAdjacent(map, randX, randY))
            {
                int randCellIndex = Random.Range(0, cellPrefabs.Length);
                GameObject cellPrefab = cellPrefabs[randCellIndex];

                GameObject cellObject = Instantiate(cellPrefab, new Vector3(randX, 0, randY), Quaternion.identity);
                cellObject.transform.SetParent(transform);

                map[randX, randY] = 1;
                cellCount++;
            }
        }

        return map;
    }

    private bool IsAdjacent(int[,] map, int x, int y)
    {
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < map.GetLength(0) && j >= 0 && j < map.GetLength(1))
                {
                    if (map[i, j] != 0)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
