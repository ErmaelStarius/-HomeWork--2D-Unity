using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.WSA;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]

    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(var pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();

            //GameObject folder = Instantiate(new GameObject(pool.tag), transform);

            GameObject folder = new GameObject(pool.tag);
            folder.transform.SetParent(transform);
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, folder.transform);

                obj.SetActive(false);
                queue.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, queue);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject obj = poolDictionary[tag].Dequeue();
        poolDictionary[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;

    }
}