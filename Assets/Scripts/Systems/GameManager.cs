using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameOverUIController gameOverUIController;

    public static GameManager Instance {get; private set;}

    public bool isGameOver {get; private set;}


    void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        gameOverUIController.Activate();
    }
}
