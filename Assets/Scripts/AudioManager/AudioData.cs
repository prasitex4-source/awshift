using FMODUnity;
using UnityEngine;

public interface IAudioSystem
{
    void PlaySFX(EventReference data, Vector3 position = default);
    void PlaySFX(EventReference data, Vector3 position, float parameterValue, string parameterName);
    void PlaySFX(EventReference data, Vector3 position, string parameterValue, string parameterName);
    void PlayMusic(EventReference data);
    void StopMusic();
}

