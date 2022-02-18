using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableCharacter : MonoBehaviour
{
    [HideInInspector] public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    private void Update()
    {
        if(health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }

    public void receiveDamage(int amount)
    {
        health -= amount;
    }
}
