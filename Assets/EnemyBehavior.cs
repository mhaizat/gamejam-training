using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemyBehaviorScriptableObject enemyBehavior;

    public Mesh enemyMeshFilter;

    [SerializeField] private LayerMask ground;

    private int currentPathIndex;
    private float tolerance = 0.01f;

    public string name;
    public float health;
    public float defense;
    public float walkSpeed;

    void Start()
    {
        name = enemyBehavior.enemyName;
        health = enemyBehavior.enemyHealth;
        defense = enemyBehavior.enemyDefense;
        walkSpeed = enemyBehavior.enemyWalkSpeed;

        enemyMeshFilter = GetComponent<Mesh>();
        enemyMeshFilter = enemyBehavior.enemyMeshFilter;

        AddUnitToList();
        StartCoroutine(FollowPathCoroutine(ManagerHub.Instance.GetGridManager().GetPathList()));
    }

    void AddUnitToList()
    {
        ManagerHub.Instance.GetUnitManager().AddUnitToList(this);
    }

    private void OnDestroy()
    {
        ManagerHub.Instance.GetUnitManager().RemoveUnitFromList(this);
    }

    private IEnumerator FollowPathCoroutine(List<Vector2Int> pathList)
    {
        while (currentPathIndex < pathList.Count)
        {
            Vector3 pathPosition = new Vector3(pathList[currentPathIndex].x, transform.position.y, pathList[currentPathIndex].y);

            while (Vector3.Distance(transform.position, pathPosition) > tolerance)
            {
                transform.position = Vector3.MoveTowards(transform.position, pathPosition, walkSpeed * Time.deltaTime);
                yield return null;
            }

            currentPathIndex++;
        }
    }
}
