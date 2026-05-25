using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractuableControler : MonoBehaviour
{
    [SerializeField] Camera mCamera;
    [SerializeField] float interactDistance = 10f;
    [SerializeField] TextMeshProUGUI interactText;

    Iinteractuable currentTargetInter;
    IPulsable currentTargetButton; 

    void Update()
    {
        UpdateCurrentInter();
        CheckForInter();
        UpdateCurrentInterMaterial();
    }

    void UpdateCurrentInter()
    {
        var ray = mCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        Physics.Raycast(ray, out var hit, interactDistance);

        if (hit.collider != null)
        {

            var interactuable = hit.collider.GetComponent<Iinteractuable>();
            if (interactuable != null)
            {

                currentTargetButton = null;
                currentTargetInter = interactuable;
                return;
            }


            var pulsable = hit.collider.GetComponent<IPulsable>();
            if (pulsable != null)
            {

                if (currentTargetInter != null)
                {
                    currentTargetInter.QuitarResalte();
                    currentTargetInter = null;
                }
                currentTargetButton = pulsable;
                return;
            }
        }

        if (currentTargetInter != null)
        {
            currentTargetInter.QuitarResalte();
            currentTargetInter = null;
        }
        currentTargetButton = null;
    }

    void CheckForInter()
    {
        if (Keyboard.current[Key.E].wasPressedThisFrame)
        {
            if (currentTargetInter != null)
            {
                currentTargetInter.Interact();
                return;
            }

            if (currentTargetButton != null)
            {
                currentTargetButton.Press();
            }
        }
        else if (Keyboard.current[Key.Escape].wasPressedThisFrame)
        {
            if (currentTargetInter != null)
                currentTargetInter.ExitInteract();
        }
    }

    void UpdateCurrentInterMaterial()
    {
        if (currentTargetInter == null) return;
        currentTargetInter.Resaltar();
    }
}