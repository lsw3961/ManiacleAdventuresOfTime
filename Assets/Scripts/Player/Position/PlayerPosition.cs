using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private CheckPointManager cpm;
    private void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckPointManager>();
        transform.position = cpm.lastCheckPointPos;
    }
}
