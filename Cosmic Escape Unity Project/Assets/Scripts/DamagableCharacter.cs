using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableCharacter : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] private GameManager gameManager;
    private GameObject playerAttacking;
    [HideInInspector] public int gameWinner;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                playerAttacking.GetComponent<KillCount>().amountOfKills++;
                gameManager.enemiesLeftInMiniGame--;
            }
            else if (gameObject.tag == "Player")
            {
                gameManager.playersLeftInMiniGame--;
            }

            if (gameManager.playersLeftInMiniGame == 0)
            {
                FinishGame();
            }
            else if (gameManager.enemiesLeftInMiniGame == 0)
            {
                FinishGame();
            }

            Destroy(gameObject);
        }
    }

    private void FinishGame()
    {
        SelectWinner();
        //AwardHousePoints();
        //DeductPointsFromDefeatedPlayers();
    }

    private void SelectWinner()
    {
        List<int> killCounts = new List<int>();

        foreach (Transform player in gameManager.playerTransforms)
        {
            killCounts.Add(player.GetComponent<KillCount>().amountOfKills);
        }

        int highestKill = 0;

        for (int i = 0; i < killCounts.Count; i++)
        {
            if(killCounts[i] >= highestKill)
            {
                highestKill = killCounts[i];
                gameWinner = i;
                print("Winner: " + gameWinner);
            }
        }
    }

    public void DeductHealth(float amount, GameObject playerDamaging)
    {
        health -= amount;
        playerAttacking = playerDamaging;
    }

    private void Start()
    {
        if(gameObject.tag == "Player")
        {
            gameManager.playersLeftInMiniGame++;
        }
        else if (gameObject.tag == "Enemy")
        {
            gameManager.enemiesLeftInMiniGame++;
        }
    }
}
