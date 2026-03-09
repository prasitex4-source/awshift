using UnityEngine;

public interface Iinteractuable
{
    public void Interact();
    public void Resaltar();
    public void QuitarResalte();
    public string InteractuableMessage { get; }
}
public abstract class InteractuableObject : MonoBehaviour, Iinteractuable
{

    public string InteractuableMessage
    {
        get { return interactuableMessage; }
    }

    [SerializeField] string interactuableMessage;

    public abstract void Interact();
    public abstract void Resaltar();
    public abstract void QuitarResalte();
}
