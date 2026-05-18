using System.Collections;
using UnityEngine;
using Yarn.Unity;
 
public class PhoneObject : InteractuableObject
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private float ringDelay = 5f;
    [SerializeField] private string yarnNode = "ChrisDialogueScript";
    [SerializeField] private string yarnNode2 = "SarahDialogue_Script";
    [SerializeField] private string yarnNode3 = "DavidDialogue_Script";
    [SerializeField] private string yarnNode4 = "JenniferDialogue_Script";
 
    private Vector3 originalPos;
    private Quaternion originalRot;
    private bool canAnswer = false;
    private bool answered = false;
 
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;
        StartCoroutine(StartPhoneRing());
    }
 
    IEnumerator StartPhoneRing()
    {
        // Desactivar el highlight/interacción hasta que suene
        yield return new WaitForSeconds(ringDelay);
        canAnswer = true;
        Debug.Log("RING RIIIIING");
    }
 
    public override void Interact()
    {
        // Si aún no ha sonado el teléfono, no hacer nada
        if (!canAnswer || answered) return;
 
        answered = true;
        Debug.Log("HAS CONTESTADO");
 
        /*GameController.Instance.isCameraFixed = true;
        Cursor.lockState = CursorLockMode.Confined;
        Camera.main.transform.rotation = Quaternion.identity;*/
        //Timer.instance.
        dialogueRunner.StartDialogue(yarnNode);
    }
 
    public override void Resaltar()
    {
        // Solo resaltar si el teléfono puede contestarse
        if (!canAnswer || answered) return;
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 10f);
    }
 
    public override void QuitarResalte()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }
 
    public override void ExitInteract()
    {
       /* GameController.Instance.isCameraFixed = false;
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = originalPos;
        transform.rotation = originalRot;*/
    }
}
