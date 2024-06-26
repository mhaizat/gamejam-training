using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager Instance;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [SerializeField] public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> normalWaveDictionary;
    public Dictionary<string, Queue<GameObject>> bossWaveDictionary;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        CreateWavePool();
    }

    private void CreateWavePool()
    {
        normalWaveDictionary = new Dictionary<string, Queue<GameObject>>();

        GameObject enemyParentObject = new GameObject("Enemy Holder");
        enemyParentObject.transform.position = Vector3.zero;

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject _object = Instantiate(pool.prefab);

                EnemyBehavior enemy = _object.GetComponent<EnemyBehavior>();
                
                if (enemy) enemy.SetTag(pool.tag);

                _object.SetActive(false);
                _object.transform.SetParent(enemyParentObject.transform);
                objectPool.Enqueue(_object);
            }

            normalWaveDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!normalWaveDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn = normalWaveDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    public void ReturnToPool(string tag, GameObject spawnedEnemy, bool isSpecial = false)
    {
        var dictionary = isSpecial ? bossWaveDictionary : normalWaveDictionary;

        if (!dictionary.ContainsKey(tag))
        {
            return;
        }

        spawnedEnemy.SetActive(false);
        dictionary[tag].Enqueue(spawnedEnemy);
    }

    public string GetWaveMobByLevel(int level)
    {
        switch (level)
        {
            case 1:
                return "Cube";
            case 2:
                return "Sphere";
            case 3:
                return "Cube";
                
                //! Can add more levels
                //!
                //!
                //!
                //!

            default:
                return null;
        }

    }
}
