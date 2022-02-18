using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteriodGameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    private float countdownTimer;
    [SerializeField] private float timeLimit;
    private bool timing;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        timing = true;
        countdownTimer = timeLimit;
    }

    private void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        if (countdownTimer > 0 && timing)
        {
            countdownTimer -= Time.deltaTime;
            timeText.text = countdownTimer.ToString("0.00");
        }
        else if (countdownTimer <= 0)
        {
            timing = false;

            // Select winner
            // give rewards
            // Move onto mainlevel
        }
    }
}
