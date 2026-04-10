using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private RectTransform _rt;

    [SerializeField] private float pointerEnterScale = 1.1f;
    [SerializeField] private float pointerDownScale = .95f;
    [SerializeField] private float animationTime = 0.5f;

    private void Awake()
    {
        _rt = GetComponent<RectTransform>();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _rt.DOScale(1f, animationTime).SetEase(Ease.OutBack);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _rt.DOScale(pointerDownScale, animationTime).SetEase(Ease.OutBack)
        .OnComplete(() =>
        {
            _rt.DOScale(1f, animationTime).SetEase(Ease.OutBounce);
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _rt.DOScale(pointerEnterScale, animationTime).SetEase(Ease.OutBack);
    }

}
