using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private List<Transform> player1WayPoints, player2WayPoints, player3WayPoints, player4WayPoints;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BoardAgent boardAgent1, boardAgent2, boardAgent3, boardAgent4;

    private void Start()
    {
        PopulateBoardPointPositions(1);
        PopulateBoardPointPositions(2);
        PopulateBoardPointPositions(3);
        PopulateBoardPointPositions(4);

        boardAgent1.GoToWaypoint(player1WayPoints[1]);
        //boardAgent2.GoToWaypoint(player2WayPoints[2]);
        //boardAgent3.GoToWaypoint(player3WayPoints[3]);
        //boardAgent4.GoToWaypoint(player4WayPoints[4]);
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
