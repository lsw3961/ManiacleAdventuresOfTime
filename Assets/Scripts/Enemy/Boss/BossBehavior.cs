using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour
{
    public int health = 100;
    public int Damage = 1;
    public PlayerLife player;
    private float shotTime = 1.5f;
    [SerializeField] private Animator animator;
    public Slider slider;

    public void FixedUpdate()
    {
        if (shotTime >0)
        {
            shotTime -= Time.deltaTime;
        }
        slider.value = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.Damage();
        }
        else if (collision.tag == "Ammo")
        {
            animator.SetTrigger("hit");
            health--;
        }
    }

}
