using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBehavior", menuName = "ScriptableObjects/Create Enemy Behavior", order = 1)]
public class EnemyBehaviorScriptableObject : ScriptableObject
{
    public Mesh enemyMeshFilter;

    public Material enemyMaterial;

    public string enemyName;
    
    public float enemyWalkSpeed;
    public float enemyHealth;
    public float enemyDefense;
}