using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableCharacter : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            if (gameObject.tag == "Player")
            {
                gameManager.GameOver();
            }
        }

        
    }

    public void DeductHealth(float amount)
    {
        health -= amount;
    }
}
