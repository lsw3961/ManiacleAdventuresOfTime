using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour
{
    public int health = 100;
    public int Damage = 1;
    private float shotTime = 1.5f;
    [SerializeField] private Animator animator;
    public Slider slider;
    private HurtPlayer player;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<HurtPlayer>();
    }
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
            player.Hurt();
        }
        else if (collision.tag == "Ammo")
        {
            animator.SetTrigger("hit");
            health--;
        }
    }

}
