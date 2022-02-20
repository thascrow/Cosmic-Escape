using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
