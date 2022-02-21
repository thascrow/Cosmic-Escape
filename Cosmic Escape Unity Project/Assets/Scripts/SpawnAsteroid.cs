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

    private void Start()
    {
        transform.position = new Vector3(0, Camera.main.transform.position.y + 2, 0);

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
        rb = Instantiate(asteroidPrefab, GetNewPos(), transform.rotation);
        rb.velocity = transform.forward * asteroidFallSpeed;
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
}
