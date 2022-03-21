using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    [SerializeField] private float spawnDelay;
    private float timeSinceLastSpawn;
    [SerializeField] private Rigidbody asteroidPrefab;
    private Vector3 newPos;
    [SerializeField] private float asteroidFallSpeed;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool spawnAtPlayerPos;
    [SerializeField] private float spawnPointDistanceFromCamera;
    private int activePlayerCheckLoopIterations;

    private void Start()
    {
        transform.position = new Vector3(0, Camera.main.transform.position.y * spawnPointDistanceFromCamera, 0);

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= spawnDelay)
        {
            Spawn();
            timeSinceLastSpawn = 0;
        }
    }

    private void Spawn()
    {
        Rigidbody rb;

        if (spawnAtPlayerPos == false)
        {
            rb = Instantiate(asteroidPrefab, GetNewPos(), transform.rotation);
            rb.velocity = transform.forward * asteroidFallSpeed;
        }
        else
        {
            rb = Instantiate(asteroidPrefab, SpawnAtPlayerPos(), transform.rotation);
            rb.velocity = transform.forward * asteroidFallSpeed;
        }

        gameManager.points += 1.11f;
    }

    Vector3 GetNewPos()
    {
        float floorWidth = floor.transform.localScale.x * 10;
        float floorHeight = floor.transform.localScale.z * 10;

        float floorRandomWidth = Random.Range(-floorWidth / 2, floorWidth / 2);
        float floorRandomHeight = Random.Range(-floorHeight / 2, floorHeight / 2);

        Vector3 randomPointOnFloor = new Vector3(floorRandomWidth, transform.position.y, floorRandomHeight);
        newPos = randomPointOnFloor;

        return newPos;
    }

    Vector3 SpawnAtPlayerPos()
    {
        int randomPlayerTransform = RandomPlayer();

        GameObject selectedPlayer = gameManager.playerTransforms[randomPlayerTransform].gameObject;

        while (selectedPlayer.activeSelf == false)
        {
            int newRandomPlayerTransform = RandomPlayer();
            GameObject newSelectedPlayer = gameManager.playerTransforms[newRandomPlayerTransform].gameObject;
            

            if (newSelectedPlayer.activeSelf == true)
            {
                selectedPlayer = newSelectedPlayer;
                break;
            }
            else if(activePlayerCheckLoopIterations >= 4)
            {
                break;
            }
            else
            {
                activePlayerCheckLoopIterations++;
            }
        }

        float playerX = selectedPlayer.transform.position.x;
        float playerZ = gameManager.playerTransforms[randomPlayerTransform].transform.position.y;

        Vector3 asteroidAtPlayerPos = new Vector3(playerX, transform.position.y, playerZ);
        newPos = asteroidAtPlayerPos;

        return newPos;
    }

    private int RandomPlayer()
    {
        return Random.Range(0, gameManager.playerTransforms.Count);
    }
}
