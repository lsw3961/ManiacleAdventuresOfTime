using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public PlayerLife player;
    [SerializeField] private string theTag = "Damage";
    [SerializeField] private string hazard = "Hazard";
    [SerializeField] private Slider slider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == theTag)
        {
            player.Damage();
            CheckLife();
            slider.value = player.PlayerHealth;
        }
        else if (collision.gameObject.tag == hazard)
        {
            
            player.Restart();
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
