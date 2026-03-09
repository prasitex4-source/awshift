using UnityEngine;

public class InteractuableCup : InteractuableObject
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip tazaSound;
    [SerializeField] private GameObject pos;



    public override void Interact()
    {
        audiosource.PlayOneShot(tazaSound);
        transform.position = pos.transform.position;
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
