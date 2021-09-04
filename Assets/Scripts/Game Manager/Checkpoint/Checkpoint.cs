using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckPointManager cpm;

    private void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckPointManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cpm.lastCheckPointPos = this.transform.position;
        }
    }
}
