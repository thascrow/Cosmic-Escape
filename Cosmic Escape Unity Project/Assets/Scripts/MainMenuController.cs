using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] GameObject mainMenu, optionMenu;

    private void Start()
    {
        
    }
    public void Option()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
   public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
   public void ExitButton()
    {
        Application.Quit();
    }
}
