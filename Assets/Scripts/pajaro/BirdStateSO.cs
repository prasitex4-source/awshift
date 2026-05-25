using UnityEngine;

[CreateAssetMenu(fileName = "BirdState", menuName = "Bird/Bird State")]
public class BirdStateSO : ScriptableObject
{
    [TextArea] public string bubbleText;
    public Sprite sprite;
    public string fmodParameterValue;

    public string buttonText = "OK";

    public ButtonAction buttonAction;

    public int nextStateIndex; // usado si cambia de estado

    public enum ButtonAction
    {
        CloseBird,     // A
        ChangeState,   // B
        DisableAlarm   // C
    }
}