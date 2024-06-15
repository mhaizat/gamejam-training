using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private EnemyPoolManager enemyPoolManager;
    [SerializeField] private ManagerHub managerHub;

    public Button testButotn;


    void Start()
    {
        enemyPoolManager = EnemyPoolManager.Instance;
        managerHub = ManagerHub.Instance;

        //StartCoroutine(SpawnEnemyWave());

        testButotn.onClick.AddListener(TestVoi);
    }

    public void TestVoi()
    {
        StartCoroutine(SpawnEnemyWave());

    }

    public IEnumerator SpawnEnemyWave()
    {
        //! NOTE(Haizat): reiterate this coroutine until every enemy in the pool is being used
        enemyPoolManager.SpawnFromPool("Cube", managerHub.GetGridManager().GetFirstTile().transform.position, managerHub.GetGridManager().GetFirstTile().transform.rotation);

        yield return new WaitForSeconds(0.5f);
    }
}
