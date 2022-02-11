using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteriodGameUI : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] float countdownTimer = 30;
    [SerializeField] float timerLimit;
    [SerializeField] bool timerStart;
    private void Start()
    {
        timerStart = true;
    }
    private void Update()
    {
        Timer();
    }

    void Timer()
    {
        if (countdownTimer > 0 && timerStart)
        {
            countdownTimer -= Time.deltaTime;
            timerLimit = (int)countdownTimer;
            print(timerLimit);
            timeText.text = timerLimit.ToString();
            print(countdownTimer);
        }
        else if (countdownTimer <= 0)
        {
            timerStart = false;
            // Select winner
            // give rewards
            // Move onto mainlevel
        }

    }
}
