using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager gameManager;
    [SerializeField] public Transform playerTransform;
    public float points;

    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
