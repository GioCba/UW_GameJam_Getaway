using UnityEngine;

public class GameManager : MonoBehaviour
{
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

        // Show Game Over UI
    }
}
