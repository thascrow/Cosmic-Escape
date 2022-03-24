using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoardAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int playerNum;
    [SerializeField] private Transform newWayPoint;
    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        if (agent.remainingDistance <= 0)
        {
            agent.isStopped = true;
        }

        if (!agent.hasPath || agent.hasPath)
        {
            agent.SetDestination(gameManager.GetPoint());

        }
    }

    public void GoToWayPoint(Vector3 wayPointPos)
    {
        switch (playerNum)
        {
            case (1):
                print(wayPointPos);
                break;
            case (2):
                //agent.SetDestination(wayPointPos.transform.localPosition);
                break;
            case (3):
               // agent.SetDestination(wayPointPos.transform.localPosition);
                break;
            case (4):
               // agent.SetDestination(wayPointPos.transform.localPosition);
                break;
        }
    }
}
