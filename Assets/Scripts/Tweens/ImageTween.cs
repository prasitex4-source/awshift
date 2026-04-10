using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImageTween : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private float _initialAlpha;
    private bool hasTweened = true;
    [SerializeField] private float animationTime = 1f;
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _initialAlpha = _canvasGroup.alpha;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }


    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame && hasTweened)
        {
            hasTweened = false;
            _canvasGroup.DOFade(1f, animationTime)
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                hasTweened = true;
                _canvasGroup.blocksRaycasts = true;
                _canvasGroup.interactable = true;
            });
        }

        else if (Keyboard.current.eKey.wasPressedThisFrame && hasTweened)
        {
            hasTweened = false;
            _canvasGroup.DOFade(_initialAlpha, animationTime)
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                hasTweened = true;
                _canvasGroup.blocksRaycasts = false;
                _canvasGroup.interactable = false;
            });
        }
    }
}
