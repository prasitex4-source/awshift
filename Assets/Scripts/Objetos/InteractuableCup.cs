using UnityEngine;
using UnityEngine.InputSystem;

public class InteractuableCup : InteractuableObject
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip tazaSound;
    [SerializeField] private GameObject pos;
    Vector3 originalpos;

    public void Start()
    {
        originalpos = transform.position;
    }

    public override void Interact()
    {
        audiosource.PlayOneShot(tazaSound);
        transform.position = pos.transform.position;

        /*if (Keyboard.current[Key.W].wasPressedThisFrame)
        {
            transform.position = originalpos;
        }*/

    }

    public override void Resaltar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0.02f);
    }

    public override void QuitarResalte()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }

    public void StopInteract()
    {
        transform.position = originalpos;
    }
}
