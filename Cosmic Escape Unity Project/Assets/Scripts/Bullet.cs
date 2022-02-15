using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timeGliding;

    private void Update()
    {
        timeGliding += Time.deltaTime;

        // destroy the bullet after 3 seconds
        if (timeGliding > 3f)
        {
            if(gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
