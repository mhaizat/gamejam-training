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

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> normalWaveDictionary;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        normalWaveDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            { 
                GameObject _object = Instantiate(pool.prefab);
                _object.SetActive(false);
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

        //! NOTE(Haizat): this needs to be moved to when the enemy is dead or completed a lap of the path
        normalWaveDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public string GetWaveMobByLevel(int level)
    {
        switch (level)
        {
            case 1:
                return "Cube";
            case 2:
                return "Sphere";
                
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
