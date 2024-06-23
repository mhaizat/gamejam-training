using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPoolManager : MonoBehaviour
{
    public static UnitPoolManager Instance;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    //! Make it serialized private
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> unitOneDictionary;

    //! Make it serialized private
    public string currentTag;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        unitOneDictionary = new Dictionary<string, Queue<GameObject>>();

        GameObject unitParentObject = new GameObject("Unit Holder");
        unitParentObject.transform.position = Vector3.zero;

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject _object = Instantiate(pool.prefab);
                _object.SetActive(false);
                _object.transform.SetParent(unitParentObject.transform);

                objectPool.Enqueue(_object);
            }

            unitOneDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!unitOneDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn = unitOneDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        //! NOTE(Haizat): this needs to be moved to when the enemy is dead or completed a lap of the path
        unitOneDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
