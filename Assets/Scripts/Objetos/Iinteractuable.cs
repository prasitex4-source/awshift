using UnityEngine;

public interface Iinteractuable
{
    public void Interact();

    public void Resaltar();
    public void Quitar();
    public string InteractuableMessage { get; }
}
