using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private string theTag = "";
    [SerializeField] private string boundingBox = "Bounding Box";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag != theTag && collision.gameObject.tag != boundingBox)
        {
            Debug.Log("hit");
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            this.gameObject.SetActive(false);
        }
    }
}
