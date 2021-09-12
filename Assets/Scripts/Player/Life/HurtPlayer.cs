using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] PlayerLife player;
    [SerializeField] SceneController gm;
    [SerializeField] Animator anim;
    public void Hurt() 
    {
        Debug.Log("hit");
        player.Damage();
        anim.SetTrigger("hit");
    }

    public void Died() 
    {
        player.Reset();
        gm.RestartTheLevel();
    }
}
