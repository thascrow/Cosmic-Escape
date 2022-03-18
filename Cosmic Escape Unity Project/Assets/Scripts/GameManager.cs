using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public List<Transform> playerTransforms;
    [SerializeField] private GameObject gameOverUI;
    [HideInInspector] public float points;
    private int currentPlayerTurn;
    [SerializeField] private Transform board;
    [SerializeField] private Transform cam;
    [SerializeField] private BoardGameUIManager boardGameUIManager;
    private bool playerSwitchTurnFirstTimeRun;
    private int rotationAmount;
    private int player1RotationY, player2RotationY, player3RotationY, player4RotationY;
    [SerializeField] public int playersLeftInMiniGame;
    [SerializeField] public int enemiesLeftInMiniGame;
    

    [HideInInspector] public int player1HousePoints, player2HousePoints, player3HousePoints, player4HousePoints;
    [HideInInspector] public Vector3 player1BoardPos, player2BoardPos, player3BoardPos, player4BoardPos;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name != "Zorgon Mini Game")
        {
            SwitchPlayerTurn(1);
        }   
        DontDestroyOnLoad(gameObject);
        playerSwitchTurnFirstTimeRun = true;
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
                boardGameUIManager.UpdateSelectedCurrentPlayer(1);
                break;
            case 2:
                //board.Rotate(new Vector3(0, board.rotation.y + player2RotationY, 0));
                //MatchCamRotationToBoard();
                boardGameUIManager.UpdateSelectedCurrentPlayer(2);
                break;
            case 3:
                //board.Rotate(new Vector3(0, board.rotation.y + player3RotationY, 0));
                //MatchCamRotationToBoard();
                boardGameUIManager.UpdateSelectedCurrentPlayer(3);
                break;
            case 4:
                //board.Rotate(new Vector3(0, board.rotation.y + player3RotationY, 0));
                //MatchCamRotationToBoard();
                boardGameUIManager.UpdateSelectedCurrentPlayer(4);
                break;
        }
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
}
