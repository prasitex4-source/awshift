using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Yarn.Unity;

public class TestTelephoneController : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] Button Contestar;
    [SerializeField] Button Colgar;
    void Update()
    {
        if(ButtonPressed(Contestar))
        {
            StartDialogue();
        }
        if(ButtonPressed(Colgar))
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

    bool ButtonPressed(Button button)
    {
        return button != null && button.onClick != null;
    }
}
