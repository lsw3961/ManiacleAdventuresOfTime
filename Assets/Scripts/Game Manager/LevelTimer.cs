using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelTimer : MonoBehaviour
{
    public PlayerLife player;
    [SerializeField] TMP_Text timerText;
    [SerializeField] private float timeRemaining = 0;
    [SerializeField] private float startingTime = 180;

    private int minutes;
    private int seconds; 

    private void Start()
    {
        timeRemaining = startingTime;
        CalculateTimer();
    }

    public void FixedUpdate()
    {
        CalculateTimer();
        DisplayOnHud();
        if (timeRemaining <= 0)
        {
            player.Restart();
        }
        else
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    private void CalculateTimer()
    {
        minutes = (int)timeRemaining / 60;
        seconds = (int)timeRemaining % 60;
    }

    private void DisplayOnHud()
    {
        timerText.text = string.Format("Remaining Time: {0:00}:{1:00}",minutes,seconds);
    }

}
