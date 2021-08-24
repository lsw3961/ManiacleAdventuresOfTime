using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject poolPrefab;
    public int poolAmount;
    public bool willGrow;

    private List<GameObject> pooledObjects;


    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject gb = Instantiate(poolPrefab);
            gb.SetActive(false);
            pooledObjects.Add(gb);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            GameObject gb = Instantiate(poolPrefab);
            pooledObjects.Add(gb);
            return gb;
        }

        return null;
    }
}
