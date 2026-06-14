using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManeContr : MonoBehaviour
{
    [SerializeField] GameObject menu; 
    public void StartGame()
    {
        SceneManager.LoadScene("ProbandoCamara");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
