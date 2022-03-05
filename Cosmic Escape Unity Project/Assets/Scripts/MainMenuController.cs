using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] GameObject mainMenu, optionMenu;
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource mainMenuVolume;
    [SerializeField] Dropdown resolutionDropdown;
    Resolution[] resolutions;


    private void Start()
    {
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
