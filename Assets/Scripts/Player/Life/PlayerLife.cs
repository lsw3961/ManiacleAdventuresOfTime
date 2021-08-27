using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Info", menuName = "Player/Info")]
public class PlayerLife : ScriptableObject
{
    private int maxHealth = 5;
    [SerializeField] private int playerHealth = 5;
    public int PlayerHealth
    {
        get { return playerHealth;}
        set { playerHealth = value;}
    }
    [SerializeField] private bool wallJump;
    public bool WallJump
    {
        get { return wallJump; }
        set { wallJump = value; }
    }
    [SerializeField] private bool doubleJump;
    public bool DoubleJump
    {
        get { return doubleJump; }
        set { doubleJump = value; }
    }
    [SerializeField] private bool dash;
    public bool Dash
    {
        get { return dash; }
        set { dash = value; }
    }
    public void Damage()
    {
        playerHealth--;
    }
    public void Reset()
    {
        playerHealth = maxHealth;
    }

}
