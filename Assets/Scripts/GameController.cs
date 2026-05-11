
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] public ImageTween fadeImage;
    [SerializeField] PhoneObject phone;

    public bool isCameraFixed = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void CallBos()
    {
        Debug.Log("BOSS LLAMADO");
    }

    public void RestartLevel()
    {
        fadeImage.FadeIn();
    }

    public void LoadCurrentScene()
    {
        Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.buildIndex);
    }
}
