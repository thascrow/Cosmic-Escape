using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager gameManager;
    [SerializeField] public Transform playerTransform;
    [SerializeField] private GameObject gameOverUI;
    public float points;

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
