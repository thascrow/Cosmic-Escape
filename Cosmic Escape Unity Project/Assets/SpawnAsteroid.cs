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

    private void Start()
    {
        transform.position = new Vector3(0, Camera.main.transform.position.y - 2, 0);

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
        rb.transform.position = new Vector3(rb.transform.position.x, transform.position.y, rb.transform.position.z);
        rb.velocity = transform.forward * asteroidFallSpeed;
    }

    Vector3 GetNewPos()
    {
        Vector3 randomPointInCamView = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 
            Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        newPos = randomPointInCamView;

        return newPos;
    }
}
