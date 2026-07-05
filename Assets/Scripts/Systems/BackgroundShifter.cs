using UnityEngine;

public class BackgroundShifter : MonoBehaviour
{
    [Header("Background Loop Settings")]
    [SerializeField]
    private GameObject[] officeBackgrounds;
    [SerializeField]
    private GameObject[] cityBackgrounds;
    [SerializeField]
    private GameObject[] beachBackgrounds;
    [SerializeField]
    private float loopSpeed;
    [SerializeField]
    private float loopThreshold;
    [SerializeField]
    private float resetOffset;

    [HideInInspector]
    public static bool isTransition = false;

    private GameObject[] currentBackgrounds;
    private bool transitionDone = false;
    private bool transitionStarted  = false;
    private float pixelOverlapBuffer = 0.02f;
    private int nextBiomeIndex = 1;

    void Awake()
    {
        isTransition = false;
        currentBackgrounds = officeBackgrounds;
    }

    void Update()
    {
        if (GameManager.Instance.isLevelCompleted || GameManager.Instance.isGameOver || GameManager.Instance.isPause) return;

        if (!isTransition) 
        {
            Scroll(currentBackgrounds, loopSpeed);
            transitionDone = false;
            transitionStarted = false;
        } else
        {
            switch (nextBiomeIndex)
            {
                case 1:
                    Transition(currentBackgrounds, cityBackgrounds);
                    break;
                case 2:
                    Transition(currentBackgrounds, beachBackgrounds);
                    break;
            }
            
        }
        
    }

    void Scroll(GameObject[] backgrounds, float speed)
    {
        foreach (GameObject background in backgrounds)
        {
            background.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);

            if (background.transform.position.y <= loopThreshold)
            {
                float overshoot = background.transform.position.y - loopThreshold;

                float newY = loopThreshold + resetOffset + overshoot - pixelOverlapBuffer;

                background.transform.position = new Vector3(background.transform.position.x, newY, background.transform.position.z);
            }
        }
    }

    void Transition(GameObject[] oldBGs, GameObject[] newBGs)
    {
        if (!transitionStarted)
        {
            InitializeNewPositions(oldBGs, newBGs);
        }

        foreach (GameObject bg in oldBGs)
        {
            bg.transform.Translate(Vector3.down * loopSpeed * Time.deltaTime);
        }

        Scroll(newBGs, loopSpeed);

        if (newBGs[0].transform.position.y <= 0f && !transitionDone)
        {
            isTransition = false;
            transitionDone = true;
            currentBackgrounds = newBGs; 

            foreach (GameObject bg in oldBGs)
            {
                bg.SetActive(false);
            }

            nextBiomeIndex++;
        }
    }

    void InitializeNewPositions(GameObject[] oldBGs, GameObject[] newBGs)
    {
        transitionStarted = true;

        float highestY = float.MinValue;
        foreach (GameObject bg in oldBGs)
        {
            if (bg.transform.position.y > highestY)
            {
                highestY = bg.transform.position.y;
            }
        }

        float individualBackgroundHeight = 16f;

        for (int i = 0; i < newBGs.Length; i++)
        {
            newBGs[i].transform.position = new Vector3(
                newBGs[i].transform.position.x, 
                highestY + (individualBackgroundHeight * (i + 1)) - pixelOverlapBuffer, 
                newBGs[i].transform.position.z
            );
        }
    }
}
