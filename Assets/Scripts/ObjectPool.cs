using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // Prefab to pool
    public int poolSize = 50; // Number of objects in the pool

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        // Initialize the pool in Awake to ensure it's done before other scripts' Start() method
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            Debug.Log("ObjectPool: Pool is empty!");
        }
        return null; // This should only happen if the pool is emptied
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
