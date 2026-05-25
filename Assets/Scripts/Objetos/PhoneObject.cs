using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PhoneObject : InteractuableObject
{
    [Header("Phone CAM")]
    [SerializeField] public float mouseSensX = 100.0f;
    [SerializeField] public float mouseSensY = 100.0f;

    [SerializeField] public float maxRotationX = 80.0f;
    [SerializeField] public float maxRotationY = 80.0f;
    private float rotationX;
    private float rotationY;
    public static PhoneObject Instance;

    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private Transform camPos;
    private Quaternion originalCamRot;
    private Vector3 originalCamPos;

    // Lista de números y sus diálogos, se rellena desde el inspector
    [SerializeField] private List<PhoneEntry> phoneBook;
    private Dictionary<string, string> phoneDict;

    private string currentNumber = "";
    private bool inDialMode = false;

    // Llamada entrante
    private bool canAnswer = false;
    private bool answered = false;
    private string incomingNode = "";

    void Awake()
    {
        Instance = this;
        originalCamPos = Camera.main.transform.position;
        originalCamRot = Camera.main.transform.rotation;

        // Convierte la lista del inspector a diccionario para buscar rápido
        phoneDict = new Dictionary<string, string>();
        foreach (var entry in phoneBook)
            phoneDict[entry.number] = entry.yarnNode;
    }

    // --- Llamada entrante, llamado por PhoneController ---

    public void Ring(string yarnNode)
    {
        incomingNode = yarnNode;
        canAnswer = true;
        answered = false;
        Debug.Log("RING RIIIIING");
    }

    public void Reset()
    {
        canAnswer = false;
        answered = false;
        inDialMode = false;
        currentNumber = "";
        incomingNode = "";
    }

    // --- El jugador pulsa E sobre el teléfono ---

    public override void Interact()
    {
        Camera.main.transform.rotation = camPos.rotation;
        Camera.main.transform.position = camPos.position;

        // Primero comprueba si hay llamada entrante
        if (canAnswer && !answered)
        {
            answered = true;
            canAnswer = false;
            dialogueRunner.StartDialogue(incomingNode);
            return; // Sale aquí — no entra en modo marcar
        }

        // Si no hay llamada, entra en modo marcar
        inDialMode = true;
        currentNumber = "";
        Debug.Log("Modo marcar activado");
    }

    // --- Llamado por PhoneButton cuando el jugador pulsa una tecla ---

    public void PressButton(string digit)
    {
        // Si no estás en modo marcar los botones no hacen nada
        if (!inDialMode) return;

        if (digit == "CALL") { TryCall(); return; }
        if (digit == "HANG") { HangUp();  return; }

        // Acumula el número pulsado
        currentNumber += digit;
        Debug.Log($"Marcando: {currentNumber}");
    }

    void TryCall()
    {
        // Busca el número en el diccionario
        if (phoneDict.TryGetValue(currentNumber, out string node))
        {
            Debug.Log($"Llamando a {currentNumber}");
            inDialMode = false;
            dialogueRunner.StartDialogue(node);
        }
        else
        {
            Debug.Log($"Número {currentNumber} no existe");
            // Aquí puedes lanzar un sonido de error
        }

        currentNumber = "";
    }

    void HangUp()
    {
        dialogueRunner.Stop();
        inDialMode = true;
        currentNumber = "";
        Debug.Log("Colgado");
    }

    // --- Resaltado ---

    public override void Resaltar()
    {
        // Resalta si hay llamada entrante o si estás en modo marcar
        if (!canAnswer && !inDialMode) return;
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0.01f);
    }

    public override void QuitarResalte()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }

    public override void ExitInteract()
    {
        Camera.main.transform.position = originalCamPos;
        Camera.main.transform.rotation = originalCamRot;

        // Salir del modo marcar con Escape
        if (inDialMode) HangUp();

    }
}

// Clase auxiliar visible en el inspector
// Cada entrada es un número y el diálogo de Yarn que lanza
[System.Serializable]
public class PhoneEntry
{
    public string number;   // "1234"
    public string yarnNode; // "LlamadaChris"
}