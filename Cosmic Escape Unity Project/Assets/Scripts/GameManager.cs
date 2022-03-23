using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    private bool playerSwitchTurnFirstTimeRun;
    private int rotationAmount;
    private int player1RotationY, player2RotationY, player3RotationY, player4RotationY;
    [SerializeField] public int playersLeftInMiniGame;
    [SerializeField] public int enemiesLeftInMiniGame;
    [SerializeField] private GameObject diceRollScreen;
    [SerializeField] private GameObject dice;
    private bool gameBegun;
    private PlayerControls inputActions;

    [HideInInspector] public int player1HousePoints, player2HousePoints, player3HousePoints, player4HousePoints;
    [HideInInspector] public Vector3 player1BoardPos, player2BoardPos, player3BoardPos, player4BoardPos;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerSwitchTurnFirstTimeRun = true;
    }

    private void Awake()
    {
        inputActions = new PlayerControls();



        if (SceneManager.GetActiveScene().name == "Board Scene")
        {
            if (!gameBegun)
            {
                inputActions.BoardScene.BeginGame.performed += ctx => SwitchPlayerTurn(1);

                gameBegun = true;
            }
            if(diceRollScreen.activeSelf == true)
            {
                inputActions.BoardScene.RollDice.performed += ctx => Instantiate(dice, diceRollScreen.transform);
            }
        }
    }

    void SwitchPlayerTurn(int playerSwitchingTo)
    {
        currentPlayerTurn = playerSwitchingTo;

        if (playerSwitchTurnFirstTimeRun)
        {
            player1RotationY = 90;
            player2RotationY = 90 * 2;
            player3RotationY = 90 * 3;
            player4RotationY = 90 * 4;

            playerSwitchTurnFirstTimeRun = false;
        }
        else
        {
            player1RotationY = 90;
            player2RotationY = 90;
            player3RotationY = 90;
            player4RotationY = 90;
        }

        switch (playerSwitchingTo)
        {
            case 1:
                //board.Rotate(new Vector3(0, board.rotation.y + player1RotationY, 0));
                //MatchCamRotationToBoard();
                boardUIManager.UpdateSelectedCurrentPlayer(1);
                ShowDice(playerSwitchingTo);
                break;
            case 2:
                //board.Rotate(new Vector3(0, board.rotation.y + player2RotationY, 0));
                //MatchCamRotationToBoard();
                boardUIManager.UpdateSelectedCurrentPlayer(2);
                break;
            case 3:
                //board.Rotate(new Vector3(0, board.rotation.y + player3RotationY, 0));
                //MatchCamRotationToBoard();
                boardUIManager.UpdateSelectedCurrentPlayer(3);
                break;
            case 4:
                //board.Rotate(new Vector3(0, board.rotation.y + player3RotationY, 0));
                //MatchCamRotationToBoard();
                boardUIManager.UpdateSelectedCurrentPlayer(4);
                break;
        }
    }

    private void ShowDice(int playerSwitchingTo)
    {
        diceRollScreen.SetActive(true);
        Instantiate(dice, diceRollScreen.transform);
    }

    private void MatchCamRotationToBoard()
    {
        cam.transform.eulerAngles = new Vector3(
            cam.transform.rotation.eulerAngles.x,
            board.transform.rotation.y,
            cam.transform.rotation.eulerAngles.z
        );
    }

    public void SwitchPlayerTest()
    {

        if (currentPlayerTurn == 4)
        {
            SwitchPlayerTurn(1);
        }
        else
        {
            SwitchPlayerTurn(currentPlayerTurn + 1);
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        inputActions.BoardScene.Enable();
    }

    private void OnDisable()
    {
        inputActions.BoardScene.Disable();
    }
}
