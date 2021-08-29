using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonLevelController : MonoBehaviour
{
    public PlayerLife player;
    public void ChangeLevels()
    {
        SceneManager.LoadScene(player.CurerntLevel+1);
    }

}
