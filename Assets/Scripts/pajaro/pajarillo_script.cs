using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;

public class pajarillo_script : MonoBehaviour
{
    public static pajarillo_script Instance;

    [Header("Audio")]
    [SerializeField] private EventReference pajaroSound;

    [Header("States")]
    [SerializeField] private List<BirdStateSO> states;

    [Header("UI")]
    [SerializeField] private GameObject bubbleUI;
    [SerializeField] private Image bubbleImage;
    [SerializeField] private TMP_Text bubbleText;

    [SerializeField] private Button okButton;
    [SerializeField] private TMP_Text okButtonText;

    private BirdStateSO currentState;

    void Awake()
    {
        Instance = this;
        
        okButton.onClick.AddListener(() => Debug.Log("CLICK OK FUNCIONA"));
        okButton.onClick.AddListener(OnOkPressed);

        bubbleUI.SetActive(false);
        okButton.gameObject.SetActive(false);


    }

    public void SetState(int index)
    {
        if (index < 0 || index >= states.Count) return;
        SetState(states[index]);
    }

    public void SetState(BirdStateSO state)
    {
        currentState = state;
        ApplyState(state);
    }

    void ApplyState(BirdStateSO state)
    {
        bubbleUI.SetActive(true);

        bubbleText.text = state.bubbleText;
        bubbleImage.sprite = state.sprite;
        okButtonText.text = state.buttonText;

        okButton.gameObject.SetActive(false);

        AudioManager.Instance.PlaySFX(
            pajaroSound,
            transform.position,
            "PajaroParameter",
            state.fmodParameterValue
        );

        StartCoroutine(ShowButton());
    }

    IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(0.5f);
        okButton.gameObject.SetActive(true);
    }

    void OnOkPressed()
    {
        bubbleUI.SetActive(false);
    }
}