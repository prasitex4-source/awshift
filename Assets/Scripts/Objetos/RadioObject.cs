using UnityEngine;
using UnityEngine.Rendering;
using FMODUnity;

public class RadioObject : InteractuableObject
{
    [SerializeField] private EventReference audioReference;

    int song = 0;


    public override void Interact()
    {

        if (song == 2)
        {
            SoundManager.StopSong();
            song = 0;
        }
        else
        {
            AudioManager.Instance.StopMusic();
            AudioManager.Instance.PlayMusic(audioReference);
            Debug.Log(song);
            song ++;
        }
    }

    public override void Resaltar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0.01f);
    }

    public override void QuitarResalte()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }

    public override void ExitInteract()
    {
        Debug.Log("Exit Interact");
    }
}
