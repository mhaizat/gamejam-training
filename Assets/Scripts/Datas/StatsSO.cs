using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Stats", order = 1)]
public class StatsSO : ScriptableObject
{
    #region  enums
    /// <summary>
    /// Maybe can expose this for other unit like enemy and champion
    /// </summary>
    public enum TowerTypes
    {
        none,
        buffer,
        physical,
        magic
    }

    /// <summary>
    /// Maybe can expose this for other unit like enemy and champion
    /// </summary>
    public enum TowerAtkTypes
    {
        none,
        ground,
        air,
        groundAndAir
    }
    #endregion

    public TowerTypes eTowerType = TowerTypes.none;
    public TowerAtkTypes eTowerAtkType = TowerAtkTypes.none;

    [Header("Stats")]
    public float healthPoint = .0f;
    public float soulPoint = .0f;
    public int attackMinimumPoint = 0;
    public int attackMaximumPoint = 0;
    public float attackCooldown = .0f;
}
