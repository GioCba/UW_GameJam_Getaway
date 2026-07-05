using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum MenuState
{
    Main,
    Settings,
    Tutorial,
    Credits
}

public class MainMenuUIController : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject tutorialMenu;
    [SerializeField]
    private GameObject creditsMenu;

    [Header("Difficulty")]
    [SerializeField]
    private TMP_Dropdown difficultyDropdown;


    [Header("Toggles")]
    [SerializeField]
    private Toggle SFXToggle;
    [SerializeField]
    private Toggle screenShakeToggle;

    void Awake()
    {
        ShowMenu(MenuState.Main);


        string savedDifficulty = PlayerPrefs.GetString("SelectedDifficulty", "Medium");
        if (savedDifficulty == "Easy")
        {
            difficultyDropdown.value = 0;
        }
        else if (savedDifficulty == "Hard")
        {
            difficultyDropdown.value = 2;
        }
        else
        {
            difficultyDropdown.value = 1;
        }

        difficultyDropdown.RefreshShownValue();

        SFXToggle.isOn = PlayerPrefs.GetInt("SFXEnabled", 1) == 1;

        screenShakeToggle.isOn = PlayerPrefs.GetInt("ScreenShakeEnabled", 1) == 1;        
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowMenu(MenuState menu)
    {
        mainMenu.SetActive(menu == MenuState.Main);
        settingsMenu.SetActive(menu == MenuState.Settings);
        tutorialMenu.SetActive(menu == MenuState.Tutorial);
        creditsMenu.SetActive(menu == MenuState.Credits);
    }

    public void OnSettingsButton()
    {
        ShowMenu(MenuState.Settings);
    }

    public void onTutorialButton()
    {
        ShowMenu(MenuState.Tutorial);
    }

    public void OnBackButton()
    {
        ShowMenu(MenuState.Main);
    }

    public void OnCreditsButton()
    {
        ShowMenu(MenuState.Credits);
    } 

    public void OnScreenShakeToggle(bool isEnabled)
    {
        int valueToSave = isEnabled ? 1 : 0;
        PlayerPrefs.SetInt("ScreenShakeEnabled", valueToSave);
        PlayerPrefs.Save();
    }

    public void OnSFXToggle(bool isEnabled)
    {
        int valueToSave = isEnabled ? 1 : 0;
        PlayerPrefs.SetInt("SFXEnabled", valueToSave);
        PlayerPrefs.Save();
    }

    public void OnDropdownValueChanged(int index)
    {
        string diff = difficultyDropdown.options[index].text;

        OnSetDifficulty(diff);
    }

    public void OnSetDifficulty(string difficulty)
    {
        PlayerPrefs.SetString("SelectedDifficulty", difficulty);
        PlayerPrefs.Save();
    }
}
