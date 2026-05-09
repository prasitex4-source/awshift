using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImageTween : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private float _initialAlpha;
    [SerializeField] private float animationTime = 1f;
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _initialAlpha = _canvasGroup.alpha;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }



    public void FadeIn()
    {

            _canvasGroup.DOFade(1f, animationTime)
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                _canvasGroup.blocksRaycasts = true;
                _canvasGroup.interactable = true;
                GameController.Instance.LoadCurrentScene();
            });
    }

    public void FadeOut()
    {

            _canvasGroup.DOFade(_initialAlpha, animationTime)
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {

                _canvasGroup.blocksRaycasts = false;
                _canvasGroup.interactable = false;
            });
    }
}
