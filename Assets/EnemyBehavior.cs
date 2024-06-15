using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    private EnemyBehaviorScriptableObject enemyBehavior;

    [SerializeField] private LayerMask ground;

    private int currentPathIndex;
    private float tolerance = 0.01f;

    public string enemyName;
    public float health;
    public float defense;
    public float walkSpeed;

    [SerializeField] private Slider healthBar;

    void Start()
    {
        enemyName = enemyBehavior.enemyName;
        health = enemyBehavior.enemyHealth;
        defense = enemyBehavior.enemyDefense;
        walkSpeed = enemyBehavior.enemyWalkSpeed;

        SetMaxHealth(health);

        StartCoroutine(FollowPathCoroutine(ManagerHub.Instance.GetGridManager().GetPathList()));
    }

    void SetMaxHealth(float maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
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
