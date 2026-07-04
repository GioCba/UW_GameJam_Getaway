using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    [SerializeField]
    private Image[] heartImages;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;

    public void UpdateHearts(int currentHealth, int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            heartImages[i].sprite = (i < currentHealth) ? fullHeart : emptyHeart;
        }
    }
}
