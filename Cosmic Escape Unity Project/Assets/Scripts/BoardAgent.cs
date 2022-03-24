using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoardAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private int playerNum;

    private void Update()
    {
        if (agent.remainingDistance <= 0)
        {
            agent.isStopped = true;
        }
    }

    public void GoToWayPoint(Transform wayPointPos)
    {
        switch (playerNum)
        {
            case (1):
                agent.SetDestination(wayPointPos.transform.position);
                break;
            case (2):
                agent.SetDestination(wayPointPos.transform.position);
                break;
            case (3):
                agent.SetDestination(wayPointPos.transform.position);
                break;
            case (4):
                agent.SetDestination(wayPointPos.transform.position);
                break;
        }
    }
}