using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private int currentPathIndex;
    private float tolerance = 0.01f;

    private void Start()
    {
        StartCoroutine(FollowPathCoroutine(ManagerHub.Instance.GetGridManager().GetPathList()));
    }
    private IEnumerator FollowPathCoroutine(List<Vector2Int> pathList)
    {
        while (currentPathIndex < pathList.Count)
        {
            Vector3 pathPosition = new Vector3(pathList[currentPathIndex].x, transform.position.y, pathList[currentPathIndex].y);

            while (Vector3.Distance(transform.position, pathPosition) > tolerance)
            {
                transform.position = Vector3.MoveTowards(transform.position, pathPosition, 5.0f * Time.deltaTime);
                yield return null;
            }

            currentPathIndex++;
        }
    }
}
