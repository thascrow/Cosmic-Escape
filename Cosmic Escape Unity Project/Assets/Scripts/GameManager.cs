using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int health;
    [HideInInspector] public static GameManager gameManager;
    [SerializeField] public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
    }

    static public void DecreasePlayerHealth(int amount)
    {
        gameManager.health -= amount;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
