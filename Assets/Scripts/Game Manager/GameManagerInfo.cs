﻿using System.Collections;
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
    private states currentState;
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
}
