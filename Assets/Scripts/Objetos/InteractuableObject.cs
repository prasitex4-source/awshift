using UnityEngine;

public class InteractuableObject : MonoBehaviour, Iinteractuable
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
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0.008f);
    }

    public void Quitar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }
}
