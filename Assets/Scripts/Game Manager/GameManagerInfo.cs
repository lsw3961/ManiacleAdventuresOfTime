using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum states
{
    red,
    green,
    blue
}
[CreateAssetMenu(fileName = "Game Manager Info", menuName = "Game Manager/Info")]
public class GameManagerInfo : ScriptableObject
{
    [SerializeField] private states currentState;
    public float currentTime;
    public float MaxTime;
    public states CurrentState()
    {
        return currentState;
    }
    public void Change()
    {
        if (currentState == states.blue)
        {
            currentState = states.red;
            return;
        }
        else
        {
            currentState++;
        }
    }
    public void UpdateTime(float curTime)
    {
        currentTime = curTime;
    }
}
