using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class GameManager : MonoBehaviour
{
    [SerializeField] EventReference MusicData;
    [SerializeField] EventReference SFXData;

    void Start()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic(MusicData);
    }
    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            AudioManager.Instance.PlaySFX(SFXData);
        }
        else if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            AudioManager.Instance.StopMusic();
        }
    }
}

