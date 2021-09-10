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
    [SerializeField] private SceneController controller;
    [SerializeField] private HurtPlayer hurtPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == theTag)
        {
            hurtPlayer.Hurt();
            CheckLife();
            slider.value = player.PlayerHealth;
        }
        else if (collision.gameObject.tag == hazard)
        {

            controller.ChangeLevels(player.CurerntLevel);
        }
    }
    private void CheckLife()
    {
        if (player.PlayerHealth <= 0)
        {
            hurtPlayer.Died();
        }


    }
}
