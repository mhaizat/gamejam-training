using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PathType
{
    public GameObject TileObject { get; set; }
    public int x { get; set; }
    public int y { get; set; }

    public PathType(GameObject tileObject, int x, int y)
    {
        TileObject = tileObject;
        this.x = x;
        this.y = y;
    }
}

public class GridManager : MonoBehaviour
{
    private PathGenerator pathGenerator;
    
    [SerializeField] private int width = 16;
    [SerializeField] private int height = 8;
    [SerializeField] private int minPathLength = 30;

    [SerializeField] private List<PathType> pathGridList;
    [SerializeField] private List<PathType> nonPathList;

    [SerializeField] private GameObject testEnemy;


    [SerializeField] private PathCellScriptableObject[] pathCellsArray;
    [SerializeField] private PathCellScriptableObject[] environmentCellsArray;


    [SerializeField] private List<Vector2Int> pathList;

    private GameObject firstTile;
    public List<Vector2Int> GetPathList() { return pathList; }

    public GameObject GetFirstTile() { return firstTile; }

    void Start()
    {
        CreateTiles();

        pathList = pathGenerator.pathCells;
    }

    void CreateTiles()
    {
        pathGenerator = new PathGenerator(width, height);

        GameObject tileParentObject = new GameObject("Tile Holder");
        tileParentObject.transform.position = Vector3.zero;

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
            pathGridList.Add(new PathType(objectTile, pathcell.x, pathcell.y));

            objectTile.transform.SetParent(tileParentObject.transform);


            if (firstTile == null) firstTile = objectTile;
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (pathGenerator.IsCellFree(x, y))
                {
                    int randomSceneryCellIndex = Random.Range(0, environmentCellsArray.Length);
                    GameObject obj = Instantiate(environmentCellsArray[randomSceneryCellIndex].pathPrefab, new Vector3(x, 0f, y), Quaternion.identity);
                    nonPathList.Add(new PathType(obj, x, y));
                    obj.transform.SetParent(tileParentObject.transform);

                }
            }
        }

        foreach (PathType pathType in pathGridList)
        {
            List<Vector2Int> adjacentCells = pathGenerator.GetAdjacentCell(new Vector2Int(pathType.x, pathType.y));

            foreach (Vector2Int adjacentCell in adjacentCells)
            {
                for (int i = 0; i < nonPathList.Count; i++)
                {
                    if (nonPathList[i].x == adjacentCell.x && nonPathList[i].y == adjacentCell.y)
                    {
                        TileBehavior tb = nonPathList[i].TileObject.GetComponent<TileBehavior>();
                        tb.SetIsTileInteractable(true);
                    }
                }
            }
        }
    }

    public class PathGenerator
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

        public bool IsCellFree(int x, int y)
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
        public List<Vector2Int> GetAdjacentCell(Vector2Int pathPosition)
        {
            List<Vector2Int> adjacentCells = new List<Vector2Int>();

            Vector2Int[] adjacentOffsets = new Vector2Int[]
            {
                new Vector2Int(0, 1),  // Up
                new Vector2Int(1, 1),  // Top Right
                new Vector2Int(1, 0),  // Right
                new Vector2Int(1, -1), // Bottom Right
                new Vector2Int(0, -1), // Down
                new Vector2Int(-1, -1),// Bottom Left
                new Vector2Int(-1, 0), // Left
                new Vector2Int(-1, 1)  // Top Left
            };

            foreach (Vector2Int offset in adjacentOffsets)
            {
                Vector2Int cellPosition = new Vector2Int(pathPosition.x + offset.x, pathPosition.y + offset.y);
                if (!pathCells.Contains(cellPosition) && IsWithinBounds(cellPosition.x, cellPosition.y))
                {
                    adjacentCells.Add(cellPosition);
                }
            }

            return adjacentCells;
        }

        private bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < gridWidth && y >= 0 && y < gridHeight;
        }
    }
}
