using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] GameObject mainMenu, optionMenu, creditsMenu;
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource mainMenuVolume;
    [SerializeField] Dropdown resolutionDropdown;
    Resolution[] resolutions;


    private void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);

        resolutions = Screen.resolutions;
       
        resolutionDropdown.ClearOptions();

        int curResolutionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        
        if (Input.GetButton("Xbox A") && mainMenu.activeInHierarchy)
        {
            PlayGame();
        }
        if (Input.GetButton("Xbox X") && mainMenu.activeInHierarchy)
        {
            Option();
        }
        if (Input.GetButton("Xbox Y") && mainMenu.activeInHierarchy)
        {
            Credits();
        }
        if (Input.GetButton("Xbox B") && mainMenu.activeInHierarchy)
        {
            ExitButton();
        }
        if (Input.GetButton("Xbox B") && optionMenu.activeInHierarchy)
        {
            OptionBackButton();
        }
        if (Input.GetButton("Xbox B") && creditsMenu.activeInHierarchy)
        {
            CreditsBackButton();
        }
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void CreditsBackButton()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
    public void Option()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
    public void OptionBackButton()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
   public void ExitButton()
    {
        Application.Quit();
    }
   public void SetVolume(float volume)
    {
        volume = volumeSlider.value;
        print(volume);
        mainMenuVolume.volume = volume;
    }
    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
    
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    
    public void SetResolution(int index)
    {
        
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        
        
        print(index + " " + Screen.currentResolution);
        
        
    }

}
