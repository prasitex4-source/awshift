using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractuableCup : InteractuableObject
{
    [SerializeField] private EventReference tazaSound;
    [SerializeField] private GameObject pos;
    [SerializeField] private float thickness;
    Vector3 originalpos;

    public void Start()
    {
        originalpos = transform.position;
    }

    public override void Interact()
    {
        AudioManager.Instance.PlaySFX(tazaSound, transform.position);
        transform.position = pos.transform.position;

    }

    public override void Resaltar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", thickness);
    }

    public override void QuitarResalte()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }

    public override void ExitInteract()
    {
        transform.position = originalpos;
    }
}
