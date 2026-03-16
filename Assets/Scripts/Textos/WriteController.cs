using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class WriteController : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;

    [Header ("Texto")]
    [SerializeField] private string fullText = "Hola hola buenas :)";

    private int revealedCount = 0;
    private bool finished = false;

    void Start()
    {
        displayText.text = "";
    }

    void OnEnable()
    {
        Keyboard.current.onTextInput += onAnyKey;
    }

void OnDisable()
    {
        Keyboard.current.onTextInput -= onAnyKey;
    }

void onAnyKey (char c)
    {
        RevealText();
    }

void RevealText()
    {
        if(finished) return;

        if(revealedCount >= fullText.Length)
        {
            finished = true;
            return;
        }

        revealedCount++;
        displayText.text = fullText.Substring(0, revealedCount);

    }




}
