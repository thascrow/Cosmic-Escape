using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int targetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = gameManager.playerTransforms[targetPlayer - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}
