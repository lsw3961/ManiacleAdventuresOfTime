using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] PlayerLife player;
    [SerializeField] Animator anim;
    public void Hurt() 
    {
        player.Damage();
        anim.SetTrigger("hit");
        Debug.Log("hit");
    }

    public void Died() 
    {
        Debug.Log("You have died.");
        player.Reset();
    }
}
