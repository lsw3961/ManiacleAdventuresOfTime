using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int healthNumber = 3;
    [SerializeField] private string theTag = "Ammo";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == theTag)
        {
            healthNumber--;
        }
        if (healthNumber <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
