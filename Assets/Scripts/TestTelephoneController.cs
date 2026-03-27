using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class TestTelephoneController : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            StartDialogue();
        }
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            StopDialogue();
        }
    }

    void StartDialogue()
    {
        dialogueRunner.StartDialogue("Test_IntroDialogue");
    }

    void StopDialogue()
    {
        if(dialogueRunner.IsDialogueRunning)
        {
            dialogueRunner.Stop();
        }
    }
}
