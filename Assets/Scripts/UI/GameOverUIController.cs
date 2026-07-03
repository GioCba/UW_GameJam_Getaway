using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    [Header("Menu Object")]
    [SerializeField]
    private GameObject gameOverObject;

    void Awake()
    {
        gameOverObject.SetActive(false);
    }

    public void Activate()
    {
        gameOverObject.SetActive(true);
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
