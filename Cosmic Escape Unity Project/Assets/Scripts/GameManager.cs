using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int player1Health, player2Health, player3Health, player4Health;
    [HideInInspector] public int currentPlayer;
    [HideInInspector] public static GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player1Health = 100;
        player2Health = 100;
        player3Health = 100;
        player4Health = 100;

        currentPlayer = 1;

        gameManager = this;
    }

    static public void DecreaseHealth(int amount)
    {
        if(gameManager.currentPlayer == 1)
        {
            gameManager.player1Health -= amount;
        }
        else if (gameManager.currentPlayer == 2)
        {
            gameManager.player2Health -= amount;
        }
        else if (gameManager.currentPlayer == 3)
        {
            gameManager.player3Health -= amount;
        }
        else if (gameManager.currentPlayer == 4)
        {
            gameManager.player4Health -= amount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
