using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{
    public PlayerLife player;
    [SerializeField] private string theTag = "Damage";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == theTag)
        {
            player.Damage();
            CheckLife();
        }
    }
    private void CheckLife()
    {
        if (player.PlayerHealth <= 0)
        {
            Debug.Log("You have died.");
            player.Reset();
        }


    }
}
