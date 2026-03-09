using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public bool isCameraFixed = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
