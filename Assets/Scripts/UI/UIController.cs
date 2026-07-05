using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayState
{
    Playing,
    Paused,
    Completed,
    Over
}

public class UIController : MonoBehaviour
{
    [Header("Menu Object")]
    [SerializeField]
    private GameObject gameOverObject;
    [SerializeField]
    private GameObject playingUIObject;
    [SerializeField]
    private GameObject pauseUIObject;
    [SerializeField]
    private GameObject levelCompletedUIObject;

    [SerializeField]
    private TMP_Text counterText;

    void Awake()
    {
        UpdateCounter(0);
        ShowMenu(PlayState.Playing);
    }

    public void ShowMenu(PlayState state)
    {
        playingUIObject.SetActive(state == PlayState.Playing);
        pauseUIObject.SetActive(state == PlayState.Paused);
        levelCompletedUIObject.SetActive(state == PlayState.Completed);
        gameOverObject.SetActive(state == PlayState.Over);
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void UpdateCounter(int currentValue)
    {
        counterText.text = currentValue + " / 30";
    }
}
