using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] public List<Transform> playerTransforms;
    [SerializeField] private GameObject gameOverUI;
    [HideInInspector] public float points;
    [HideInInspector] public int currentPlayerTurn;
    [SerializeField] private Transform board;
    [SerializeField] private Transform cam;
    [SerializeField] private BoardUIManager boardUIManager;
    [SerializeField] public int playersLeftInMiniGame;
    [SerializeField] public int enemiesLeftInMiniGame;
    [SerializeField] private GameObject dice;
    private bool gameBegun;
    private bool ableToAdvance;
    [SerializeField] private BoardManager boardManager;
    [SerializeField] public Transform boardAgent1, boardAgent2, boardAgent3, boardAgent4;
    private int player1CurrentPos, player2CurrentPos, player3CurrentPos, player4CurrentPos;
    [HideInInspector] public int player1HousePoints, player2HousePoints, player3HousePoints, player4HousePoints;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Board Scene")
        {
            if (Input.GetButtonDown("Xbox A"))
            {
                if (!gameBegun)
                {
                    SwitchPlayerTurn(1);
                    gameBegun = true;
                }
                if (ableToAdvance == true)
                {
                    boardUIManager.diceRollScreen.SetActive(false);
                }
            }
        }
    }

    public void DiceRolled(int rolledFace)
    {
        boardUIManager.diceRollHint.SetActive(false);
        boardUIManager.diceRolledText.SetActive(true);

        AdvancePlayerOnBoard(rolledFace);
    }

    private void AdvancePlayerOnBoard(int rolledFace)
    {
        ableToAdvance = true;

        switch (currentPlayerTurn)
        {
            case 1:
                boardAgent1.transform.position = boardManager.player1WayPoints[player1CurrentPos + rolledFace - 1].transform.position;
                player1CurrentPos += rolledFace - 1;
                break;
            case 2:
                boardAgent2.transform.position = boardManager.player2WayPoints[player2CurrentPos + rolledFace - 1].transform.position;
                player2CurrentPos += rolledFace - 1; 
                break;
            case 3:
                boardAgent3.transform.position = boardManager.player3WayPoints[player3CurrentPos + rolledFace - 1].transform.position;
                player3CurrentPos += rolledFace - 1; 
                break;
            case 4:
                boardAgent4.transform.position = boardManager.player4WayPoints[player4CurrentPos + rolledFace - 1].transform.position;
                player4CurrentPos += rolledFace - 1; 
                break;
        }
    }

    void SwitchPlayerTurn(int playerSwitchingTo)
    {
        currentPlayerTurn = playerSwitchingTo;

        switch (playerSwitchingTo)
        {
            case 1:
                boardUIManager.UpdateSelectedCurrentPlayer(1);
                ShowDice(playerSwitchingTo);
                break;
            case 2:
                boardUIManager.UpdateSelectedCurrentPlayer(2);
                ShowDice(playerSwitchingTo);
                break;
            case 3:
                boardUIManager.UpdateSelectedCurrentPlayer(3);
                ShowDice(playerSwitchingTo);
                break;
            case 4:
                boardUIManager.UpdateSelectedCurrentPlayer(4);
                ShowDice(playerSwitchingTo);
                break;
        }
    }

    private void ShowDice(int playerSwitchingTo)
    {
        boardUIManager.diceRollScreen.SetActive(true);
        Instantiate(dice, boardUIManager.diceRollScreen.transform);
        boardUIManager.beginGameText.SetActive(false);
    }
}
