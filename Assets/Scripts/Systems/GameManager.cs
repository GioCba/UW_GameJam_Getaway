using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIController UIController;

    public static GameManager Instance {get; private set;}

    public bool isGameOver {get; private set;}

    public bool isLevelCompleted {get; private set;}

    public bool isPause {get; private set;}


    void Awake()
    {
        Instance = this;

        Time.timeScale = isPause ? 0f : 1f;
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        UIController.ShowMenu(PlayState.Over);
    }

    public void LevelCompleted()
    {
        if (isLevelCompleted) return;

        isLevelCompleted = true;

        UIController.ShowMenu(PlayState.Completed);
    }

    public void PauseGame()
    {
        isPause = !isPause;

        Time.timeScale = isPause ? 0f : 1f;

        UIController.ShowMenu(isPause ? PlayState.Paused : PlayState.Playing);
    }
}
