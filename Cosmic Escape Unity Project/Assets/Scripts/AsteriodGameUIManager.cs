using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteriodGameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI pointsText;
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
        UpdateUI();
    }

    private void UpdateUI()
    {
        pointsText.text = gameManager.points.ToString("00.00");
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
