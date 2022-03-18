using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPointPositions;
    [SerializeField] private GameManager gameManager;

    public void GoToWaypoint(int playerNum, int wayPoint)
    {
        //gameManager.playerTransforms[playerNum].transform = wayPointPositions[].transform;
    }
}
