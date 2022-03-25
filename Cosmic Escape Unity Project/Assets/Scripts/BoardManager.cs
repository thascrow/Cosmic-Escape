using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] public List<Transform> player1WayPoints, player2WayPoints, player3WayPoints, player4WayPoints;

    private void Awake()
    {
        PopulateBoardPointPositions(1);
        PopulateBoardPointPositions(2);
        PopulateBoardPointPositions(3);
        PopulateBoardPointPositions(4);
    }

    private void Start()
    {
        gameManager.player1CurrentPos
    }

    private void PopulateBoardPointPositions(int playerNum)
    {
        foreach (GameObject boardPoint in GameObject.FindGameObjectsWithTag("Player " + playerNum + " Board Point"))
        {
            switch (playerNum)
            {
                case 1:
                    player1WayPoints.Add(boardPoint.transform);
                    break;
                case 2:
                    player2WayPoints.Add(boardPoint.transform);
                    break;
                case 3:
                    player3WayPoints.Add(boardPoint.transform);
                    break;
                case 4:
                    player4WayPoints.Add(boardPoint.transform);
                    break;
            }
        }
    }
}
