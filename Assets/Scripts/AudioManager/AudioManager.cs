using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour, IAudioSystem
{
    public static IAudioSystem Instance { get; private set; }

    private EventInstance musicInstance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    public void PlaySFX(EventReference data, Vector3 position = default)
    {
        if (data.IsNull) return;

        RuntimeManager.PlayOneShot(data,position);
    }

    public void PlaySFX(EventReference data, Vector3 position, float parameterValue, string parameterName)
    {
        if(data.IsNull) return;

        EventInstance instance = RuntimeManager.CreateInstance(data);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(position));

        instance.setParameterByName(parameterName, parameterValue);
        instance.start();
        instance.release();
    }
    public void PlaySFX(EventReference data, Vector3 position, string parameterValue, string parameterName)
    {
        if(data.IsNull) return;

        EventInstance instance = RuntimeManager.CreateInstance(data);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(position));

        instance.setParameterByNameWithLabel(parameterName, parameterValue);

        instance.start();
        instance.release();
    }

    public void PlayMusic(EventReference data)
    {
        if (data.IsNull)
        {
            StopMusic();
            return;
        }

        musicInstance = RuntimeManager.CreateInstance(data);
        musicInstance.start();

    }

    public void StopMusic()
    {
        if (musicInstance.isValid())
        {
            return;
        }

        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance.release();
    }
}
