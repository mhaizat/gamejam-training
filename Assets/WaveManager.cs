using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private EnemyPoolManager enemyPoolManager;
    [SerializeField] private ManagerHub managerHub;

    public Button testButotn;

    string waveTag;

    void Start()
    {
        enemyPoolManager = EnemyPoolManager.Instance;
        managerHub = ManagerHub.Instance;

        //! NOTE(Haizat): this is just a test button to see if the SpawnEnemyMove method works or not
        testButotn.onClick.AddListener(TestVoi);
    }

    //! NOTE(Haizat): this is just a test method to see if the SpawnEnemyMove method works or not
    public void TestVoi()
    {
        int waveLevel = Random.Range(1, 3);
        //! NOTE(Haizat): Reset the waveTag string value. why? i dont know bro
        waveTag = string.Empty;
        waveTag = EnemyPoolManager.Instance.GetWaveMobByLevel(waveLevel);
        StartCoroutine(SpawnEnemyWave(waveTag));
    }

    public IEnumerator SpawnEnemyWave(string waveTag)
    {
        for (int i = 0; i < enemyPoolManager.pools[0].size; i++)
        { 
            enemyPoolManager.SpawnFromPool(waveTag, managerHub.GetGridManager().GetFirstTile().transform.position, managerHub.GetGridManager().GetFirstTile().transform.rotation);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
