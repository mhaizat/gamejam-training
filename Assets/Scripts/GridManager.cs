using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject testEnemy;

    [SerializeField] private int width = 16;
    [SerializeField] private int height = 8;
    [SerializeField] private int minPathLength = 30;

    public PathCellScriptableObject[] pathCellsArray;

    private PathGenerator pathGenerator;

    public List<Vector2Int> pathList;

    public List<Vector2Int> GetPathList() { return pathList; }

    private GameObject firstTile;

    public GameObject GetFirstTile() { return firstTile; }

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
            int neighborValue = pathGenerator.GetCellNeighborValue(pathcell.x, pathcell.y);
            GameObject pathCellPrefab = pathCellsArray[neighborValue].pathPrefab;
            GameObject objectTile = Instantiate(pathCellPrefab, new Vector3(pathcell.x, 0, pathcell.y), Quaternion.identity);
            objectTile.transform.Rotate(0f, pathCellsArray[neighborValue].yRotation, 0f, Space.Self);
            Debug.Log($"X: {pathcell.x}, Y: {pathcell.y} | {neighborValue.ToString()}");
            
            if (firstTile == null) firstTile = objectTile;
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
                    else if (move == 1 && IsCellFree(x, y + 1) && y < (gridHeight - 2))
                    {
                        y++;
                        validPath = true;
                    }
                    else if (move == 2 && IsCellFree(x, y - 1) && y > 2)
                    {
                        y--;
                        validPath = true;
                    }
                }
            }

            return pathCells;
        }

        private bool IsCellFree(int x , int y)
        {
            return !pathCells.Contains(new Vector2Int(x, y));
        }

        public int GetCellNeighborValue(int x, int y)
        {
            int returnValue = 0;
            if (IsCellFree(x, y - 1))
            {
                returnValue += 1;
            }

            if (IsCellFree(x - 1, y))
            {
                returnValue += 2;
            }

            if (IsCellFree(x + 1, y))
            {
                returnValue += 4;
            }

            if (IsCellFree(x, y + 1))
            {
                returnValue += 8;
            }

            return returnValue;
        }
    }
}
