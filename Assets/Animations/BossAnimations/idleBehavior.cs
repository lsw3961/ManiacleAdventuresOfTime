using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehavior : StateMachineBehaviour
{
    public float timer = 1.5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            int rand = Random.Range(1, 2);
            if (rand == 0)
            {
                animator.SetTrigger("attack2");
            }
            else
            {
                animator.SetTrigger("attack1");
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
