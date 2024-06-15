using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EnemyBehaviorScriptableObject enemyBehavior;

    [SerializeField] private LayerMask ground;

    private int currentPathIndex;
    private float tolerance = 0.01f;

    public string enemyName;
    public float health;
    public float defense;

    [SerializeField] private Slider healthBar;

    void Start()
    {
        enemyName = enemyBehavior.enemyName;
        health = enemyBehavior.enemyHealth;
        defense = enemyBehavior.enemyDefense;

        SetMaxHealth(health);
    }

    private void OnEnable()
    {
        StartCoroutine(FollowPathCoroutine(ManagerHub.Instance.GetGridManager().GetPathList()));
    }

    private void OnDisable()
    {
        StopCoroutine(FollowPathCoroutine(ManagerHub.Instance.GetGridManager().GetPathList()));
    }

    void SetMaxHealth(float maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    private IEnumerator FollowPathCoroutine(List<Vector2Int> pathList)
    {
        while (currentPathIndex < pathList.Count || gameObject.activeInHierarchy)
        {
            Vector3 pathPosition = new Vector3(pathList[currentPathIndex].x, transform.position.y, pathList[currentPathIndex].y);

            while (Vector3.Distance(transform.position, pathPosition) > tolerance)
            {
                transform.position = Vector3.MoveTowards(transform.position, pathPosition, 1.0f * Time.deltaTime);
                yield return null;
            }

            currentPathIndex++;
        }
    }
}
