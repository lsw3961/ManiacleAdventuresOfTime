using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOutOfMap : MonoBehaviour
{
    public SceneController controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            controller.RestartTheLevel();
        }
    }
}
