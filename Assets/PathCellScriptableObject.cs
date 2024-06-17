using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PathCellType", menuName = "ScriptableObjects/Create Path Cell Type", order = 1)]

public class PathCellScriptableObject : ScriptableObject
{
    public enum pathCellType { Ground, Path}

    public pathCellType PathCellType;

    public GameObject pathPrefab;
    public float yRotation;
}
