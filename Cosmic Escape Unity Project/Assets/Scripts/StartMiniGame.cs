using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMiniGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        int randomScene = Random.Range(0, 2);

        switch (randomScene)
        {
            case 1:
                SceneManager.LoadScene("Asteroid Mini Game");
                break;
            case 2:
                SceneManager.LoadScene("Robot Mini Game");
                break;
            case 3:
                SceneManager.LoadScene("Zorgon Mini Game");
                break;
        }
    }
}
