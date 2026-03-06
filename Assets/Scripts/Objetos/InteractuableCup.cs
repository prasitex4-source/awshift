using UnityEngine;

public class InteractuableCup : MonoBehaviour, Iinteractuable
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip tazaSound;
    [SerializeField] private GameObject pos;

    public string InteractuableMessage
    {
        get { return interactuableMessage; }
    }

    [SerializeField] string interactuableMessage;



    public void Interact()
    {
        audiosource.PlayOneShot(tazaSound);
        transform.position = pos.transform.position;
    }

    public void Resaltar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0.02f);
    }

    public void Quitar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }
}
