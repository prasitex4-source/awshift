using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioManager : MonoBehaviour, IAudioSystem
{
    public static IAudioSystem Instance { get; private set; }
    
    [Header("Música")]
    [SerializeField] private AudioSource musicSource;

    [Header("SFX Pool")]
    [SerializeField] private int initalPoolSize = 15;
    private List<AudioSource> sfxPool = new List<AudioSource>();

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i < initalPoolSize; i++)
        {
            CreateNewSFXSource();
        }
    }

    private AudioSource CreateNewSFXSource()
    {
        GameObject gObject = new GameObject("SFX_Source");
        gObject.transform.SetParent(transform); 
        AudioSource aSource = gObject.AddComponent<AudioSource>();
        return aSource;
    }

    public AudioSource GetAvalibableSFXSource()
    {
        foreach(var source in sfxPool)
        {
            if(!source.isPlaying) return source;
        }
        return CreateNewSFXSource();
    }

    public void PlaySFX(AudioData data, Vector3 position = default)
    {
        if(data == null) return;

        AudioSource aSource = GetAvalibableSFXSource();
        aSource.transform.position = position;
        aSource.clip = data.GetRandomAudioClip();
        aSource.volume  = data.volume;
        aSource.pitch = data.GetRandomAudioPitch();

        aSource.Play();
    }

    public void PlayMusic(AudioData data)
    {
        if(data == null)
        {
            StopMusic();
            return;
        }

        AudioClip mClip = data.GetRandomAudioClip();
        if(musicSource.clip == mClip && musicSource.isPlaying) return;

        musicSource.clip = mClip;
        musicSource.volume = data.volume;
        musicSource.loop = data.isLooping;
        musicSource.Play();

    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
