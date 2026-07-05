using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEndingController : MonoBehaviour
{
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
