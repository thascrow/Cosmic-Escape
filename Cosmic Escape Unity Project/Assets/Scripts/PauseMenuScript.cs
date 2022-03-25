using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]GameObject pauseMenu;
    [SerializeField] AudioSource bgMusic;
    bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Xbox Start"))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        if (Input.GetButton("Xbox A") && isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        if (Input.GetButton("Xbox X") && isPaused)
        {
            bgMusic.volume = 0f;
            print("MenuMusic paused");
        }
        if (Input.GetButton("Xbox B") && isPaused)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
}
