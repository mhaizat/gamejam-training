using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject testPathTile;
    [SerializeField] private GameObject testEnemy;

    [SerializeField] private int width = 16;
    [SerializeField] private int height = 8;
    [SerializeField] private int minPathLength = 30;

    private PathGenerator pathGenerator;

    public List<Vector2Int> pathList;

    public List<Vector2Int> GetPathList() { return pathList; }

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

        pathList = pathGenerator.pathCells;
    }

    private class PathGenerator
    {
        private int gridWidth, gridHeight;

        public List<Vector2Int> pathCells;

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

                bool validPath = false;

                while (!validPath)
                {
                    int move = Random.Range(0, 3);

                    if (move == 0 || x % 2 == 0 || x > (gridWidth - 2))
                    {
                        x++;
                        validPath = true;
                    }
                    else if (move == 1 && CellIsFree(x, y + 1) && y < (gridHeight - 2))
                    {
                        y++;
                        validPath = true;
                    }
                    else if (move == 2 && CellIsFree(x, y - 1) && y > 2)
                    {
                        y--;
                        validPath = true;
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
