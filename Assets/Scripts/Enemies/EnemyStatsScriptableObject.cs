using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBehavior", menuName = "ScriptableObjects/Create Enemy Behavior", order = 1)]
public class EnemyStatsScriptableObject : ScriptableObject
{
    public Mesh enemyMeshFilter;

    public Material enemyMaterial;

    public string enemyName;
    
    public float enemyHealth;
    public float enemyDefense;
}