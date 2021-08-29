using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject gb;
    private void Start()
    {
        gb = Instantiate(prefab,this.transform);
    }

    private void Update()
    {
        if (gb.activeSelf == false)
        {
            Invoke("Reset",2f);
        }
    }
    private void Reset()
    {
        gb.transform.localPosition = Vector3.zero;
        gb.SetActive(true);
    }
}
