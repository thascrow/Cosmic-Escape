using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] public List<Transform> playerTransforms;
    [SerializeField] private GameObject gameOverUI;
    private GameObject instantiatedDice;
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
    [SerializeField] public bool testingCards;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        player1HousePoints = 3;
        player2HousePoints = 3;
        player3HousePoints = 3;
        player4HousePoints = 3;
    }

    private void Update()
    {
        boardUIManager.player1HousePoints.text = player1HousePoints.ToString();
        boardUIManager.player2HousePoints.text = player2HousePoints.ToString();
        boardUIManager.player3HousePoints.text = player3HousePoints.ToString();
        boardUIManager.player4HousePoints.text = player4HousePoints.ToString();

        if (SceneManager.GetActiveScene().name == "Board Scene")
        {
            if (Input.GetButtonDown("Xbox A"))
            {
                if (!gameBegun)
                {
                    SwitchPlayerTurn(1);
                    gameBegun = true;
                }
                if (ableToAdvance)
                {
                    boardUIManager.diceRollScreen.SetActive(false);
                    boardUIManager.diceRolledText.SetActive(false);
                    boardUIManager.diceRollHint.SetActive(true);
                    Destroy(instantiatedDice);

                    ableToAdvance = false;



                    SwitchPlayerTurn(currentPlayerTurn + 1);
                }
            }
        }
    }

    public void DiceRolled(int rolledFace)
    {
        boardUIManager.diceRollHint.SetActive(false);
        boardUIManager.diceRolledText.SetActive(true);

        AdvancePlayerOnBoard(rolledFace - 1);
    }

    public void AdvancePlayerOnBoard(int advanceBy)
    {
        ableToAdvance = true;

        switch (currentPlayerTurn)
        {
            case 1:
                boardAgent1.transform.position = boardManager.player1WayPoints[player1CurrentPos + advanceBy].transform.position;
                player1CurrentPos += advanceBy;
                break;
            case 2:
                boardAgent2.transform.position = boardManager.player2WayPoints[player2CurrentPos + advanceBy].transform.position;
                player2CurrentPos += advanceBy;
                break;
            case 3:
                boardAgent3.transform.position = boardManager.player3WayPoints[player3CurrentPos + advanceBy].transform.position;
                player3CurrentPos += advanceBy;
                break;
            case 4:
                boardAgent4.transform.position = boardManager.player4WayPoints[player4CurrentPos + advanceBy].transform.position;
                player4CurrentPos += advanceBy;
                break;
        }
    }

    IEnumerator PauseAndShowTurnCompleteMsg(float time)
    {
        yield return new WaitForSeconds(time);

        boardUIManager.turnCompleteText.SetActive(true);
        switch (currentPlayerTurn)
        {
            case 1:
                boardUIManager.turnCompleteText.GetComponent<TMP_Text>().text = "Player " + 
                    currentPlayerTurn + ", your new board position is " + player1CurrentPos;
                break;
            case 2:
                boardUIManager.turnCompleteText.GetComponent<TMP_Text>().text = "Player " +
                    currentPlayerTurn + ", your new board position is " + player2CurrentPos;
                break;
            case 3:
                boardUIManager.turnCompleteText.GetComponent<TMP_Text>().text = "Player " +
                    currentPlayerTurn + ", your new board position is " + player3CurrentPos;
                break;
            case 4:
                boardUIManager.turnCompleteText.GetComponent<TMP_Text>().text = "Player " +
                    currentPlayerTurn + ", your new board position is " + player4CurrentPos;
                break;
        }
    }

    public void SwitchPlayerTurn(int playerSwitchingTo)
    {
        if (gameBegun)
        {
            StartCoroutine(PauseAndShowTurnCompleteMsg(3));

            switch (playerSwitchingTo)
            {
                case 1:
                    boardUIManager.UpdateSelectedCurrentPlayer(1);
                    currentPlayerTurn = 1;
                    ShowDice(1);
                    break;
                case 2:
                    boardUIManager.UpdateSelectedCurrentPlayer(2);
                    currentPlayerTurn = 2;
                    ShowDice(2);
                    break;
                case 3:
                    boardUIManager.UpdateSelectedCurrentPlayer(3);
                    currentPlayerTurn = 3;
                    ShowDice(3);
                    break;
                case 4:
                    boardUIManager.UpdateSelectedCurrentPlayer(4);
                    currentPlayerTurn = 4;
                    ShowDice(4);
                    break;
                default:
                    boardUIManager.UpdateSelectedCurrentPlayer(1);
                    currentPlayerTurn = 1;
                    ShowDice(1);
                    break;
            }
        }
        else
        {
            switch (playerSwitchingTo)
            {
                case 1:
                    boardUIManager.UpdateSelectedCurrentPlayer(1);
                    currentPlayerTurn = 1;
                    ShowDice(1);
                    break;
                case 2:
                    boardUIManager.UpdateSelectedCurrentPlayer(2);
                    currentPlayerTurn = 2;
                    ShowDice(2);
                    break;
                case 3:
                    boardUIManager.UpdateSelectedCurrentPlayer(3);
                    currentPlayerTurn = 3;
                    ShowDice(3);
                    break;
                case 4:
                    boardUIManager.UpdateSelectedCurrentPlayer(4);
                    currentPlayerTurn = 4;
                    ShowDice(4);
                    break;
                default:
                    boardUIManager.UpdateSelectedCurrentPlayer(1);
                    currentPlayerTurn = 1;
                    ShowDice(1);
                    break;
            }
        }
    }

    public void ShowDice(int playerSwitchingTo)
    {
        boardUIManager.diceRollScreen.SetActive(true);
        instantiatedDice = Instantiate(dice, boardUIManager.diceRollScreen.transform);
        boardUIManager.diceRollHint.SetActive(true);
        boardUIManager.diceRolledText.SetActive(false);
        boardUIManager.beginGameText.SetActive(false);
    }
}
