using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private string tag = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != tag)
        {
            gameObject.SetActive(false);
        }
    }
}
