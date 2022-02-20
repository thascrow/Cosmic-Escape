using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timeGliding;
    [SerializeField] private float destroyTime;

    private void Update()
    {
        timeGliding += Time.deltaTime;

        // destroy the bullet after 3 seconds
        if (timeGliding > destroyTime)
        {
            if(gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
