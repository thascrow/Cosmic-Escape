using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AsteroidGameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI pointsText;
    private float countdownTimer;
    [SerializeField] private float timeLimit;
    private bool timing;
    [SerializeField] private GameManager gameManager;
    
    [SerializeField] Image p1Image, p2Image, p3Image, p4Image, deathImage;
    [SerializeField] DamagableCharacter p1Health, p2Health, p3Health, p4Health;
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
        if (p1Health.health <= 0)
        {
            p1Image.sprite = deathImage.sprite;
        }
        if (p2Health.health <= 0)
        {
            p2Image.sprite = deathImage.sprite;
        }
        if (p3Health.health <= 0)
        {
            p3Image.sprite = deathImage.sprite;
        }
        if (p4Health.health <= 0)
        {
            p4Image.sprite = deathImage.sprite;
        }
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
