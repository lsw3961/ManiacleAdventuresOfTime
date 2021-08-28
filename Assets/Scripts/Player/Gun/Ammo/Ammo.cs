using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private string theTag = "";
    [SerializeField] private string boundingBox = "Bounding Box";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != theTag && collision.gameObject.tag != boundingBox)
        {
            
            gameObject.SetActive(false);
        }
    }
}
