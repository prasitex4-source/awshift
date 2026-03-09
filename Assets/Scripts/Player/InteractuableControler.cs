using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractuableControler : MonoBehaviour
{
    [SerializeField] Camera mCamera;
    [SerializeField] float interactDistance = 5f;
    [SerializeField] TextMeshProUGUI interactText;

    Iinteractuable currentTargetInter;

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

        if(hit.collider != null)
        {        
            var interactuable = hit.collider.GetComponent<Iinteractuable>();

            if (interactuable != null)
            {
                currentTargetInter = interactuable;
                return;
            }
        }

        else
        {
            if (currentTargetInter != null)
            {
                currentTargetInter.QuitarResalte();
            }
            currentTargetInter = null;
        }
    }

    void CheckForInter()
    {
        if (Keyboard.current[Key.E].wasPressedThisFrame && currentTargetInter != null)
        {
            currentTargetInter.Interact();
        }
    }

    void UpdateCurrentInterMaterial()
    {
        if(currentTargetInter == null)
        {
            return;
        }

        //interactText.text = currentTargetInter.InteractuableMessage;
        currentTargetInter.Resaltar();
    }


}
