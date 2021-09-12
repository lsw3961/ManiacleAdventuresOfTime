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
    }

    public void Died() 
    {
        player.Reset();
    }
}
