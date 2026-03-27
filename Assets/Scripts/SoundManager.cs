using UnityEngine;

public enum SoundType
{
    UNO,
    DOS,
    TRES
}

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    [SerializeField] private AudioClip[] songsList;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySong(int num, float volume = 1)
    {
        Debug.Log("radio on");
        instance.audioSource.PlayOneShot(instance.songsList[num], volume);
    }

    public static void StopSong()
    {
        instance.audioSource.Stop();
    }
}
