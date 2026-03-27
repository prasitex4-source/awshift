using UnityEngine;
using UnityEngine.Rendering;

public class RadioObject : InteractuableObject
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] SoundManager soundManager;
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
            SoundManager.StopSong();
            SoundManager.PlaySong(song);
            Debug.Log(song);
            song ++;
        }


    }

    public override void Resaltar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0.02f);
    }

    public override void QuitarResalte()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }
}
