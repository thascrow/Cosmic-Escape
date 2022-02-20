using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]float collectibles;
    [SerializeField] bool red, blue, yellow, green;
    [SerializeField] Image head, arm, leg, body;

    private void Start()
    {
           
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Hello");
        AddScore();
        if (other.gameObject.tag == "Collectible")
        {
            Destroy(other.gameObject);
        }
    }

    private void AddScore()
    {
        
        collectibles++;

    }
}
