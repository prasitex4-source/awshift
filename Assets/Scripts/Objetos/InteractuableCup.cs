using UnityEngine;

public class InteractuableCup : MonoBehaviour, Iinteractuable
{
    public string InteractuableMessage
    {
        get { return interactuableMessage; }
    }

    [SerializeField] string interactuableMessage;

    public void Interact()
    {
        Destroy(gameObject);
    }

    public void Resaltar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0.01f);
    }

    public void Quitar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }
}
