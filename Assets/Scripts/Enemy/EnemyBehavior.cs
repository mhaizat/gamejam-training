using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    private enum EnemyType { Ground, Air };

    [SerializeField] private EnemyType enemyType;
    

    private int currentPathIndex;
    private float tolerance = 0.01f;

    private float yOffset = 2.0f;

    private void OnEnable()
    {
        StartCoroutine(FollowPathCoroutine(ManagerHub.Instance.GetGridManager().GetPathList()));
    }

    private void OnDisable()
    {
        StopCoroutine(FollowPathCoroutine(ManagerHub.Instance.GetGridManager().GetPathList()));
    }

    private IEnumerator FollowPathCoroutine(List<Vector2Int> pathList)
    {
        while (currentPathIndex < pathList.Count || gameObject.activeInHierarchy)
        {
            float yPos = enemyType == EnemyType.Ground ? transform.position.y : transform.position.y + yOffset;

            Vector3 pathPosition = new Vector3(pathList[currentPathIndex].x, yPos, pathList[currentPathIndex].y);

            while (Vector3.Distance(transform.position, pathPosition) > tolerance)
            {
                transform.position = Vector3.MoveTowards(transform.position, pathPosition, 1.0f * Time.deltaTime);
                yield return null;
            }

            currentPathIndex++;
        }
    }
}
