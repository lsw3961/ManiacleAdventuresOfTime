using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{
    PlayerLife player;
    [SerializeField] private string tag = "Ammo";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tag)
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
