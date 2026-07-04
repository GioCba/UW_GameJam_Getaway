using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Awake()
    {
        ShowMenu(MenuState.Main);
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
    
}
