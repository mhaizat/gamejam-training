using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject testPathTile;

    public int width = 16;
    public int height = 8;
    public int minPathLength = 30;

    public PathGenerator pathGenerator;

    void Start()
    {
        pathGenerator = new PathGenerator(width, height);

        List<Vector2Int> pathCells = pathGenerator.GeneratePath();
        int pathSize = pathCells.Count;

        while (pathSize < minPathLength)
        {
            pathCells = pathGenerator.GeneratePath();
            pathSize = pathCells.Count;
        }


        foreach (Vector2Int pathcell in pathCells)
        {
            Instantiate(testPathTile, new Vector3(pathcell.x, 0, pathcell.y), Quaternion.identity);
        }
    }

    public class PathGenerator
    {
        private int gridWidth, gridHeight;

        private List<Vector2Int> pathCells;

        public PathGenerator(int width, int height)
        {
            gridWidth = width;
            gridHeight = height;
        }

        public List<Vector2Int> GeneratePath()
        {
            pathCells = new List<Vector2Int>();

            int y = (int)(gridHeight / 2);
            int x = 0;

            while (x < gridWidth)
            {
                pathCells.Add(new Vector2Int(x, y));

                bool validMove = false;

                while (!validMove)
                {
                    int move = Random.Range(0, 3);

                    if (move == 0 || x % 2 == 0 || x > (gridWidth - 2))
                    {
                        x++;
                        validMove = true;
                    }
                    else if (move == 1 && CellIsFree(x, y + 1) && y < (gridHeight - 2))
                    {
                        y++;
                        validMove = true;
                    }
                    else if (move == 2 && CellIsFree(x, y - 1) && y > 2)
                    {
                        y--;
                        validMove = true;
                    }
                }
            }

            return pathCells;
        }

        private bool CellIsFree(int x , int y)
        {
            return !pathCells.Contains(new Vector2Int(x, y));
        }
    }
}
