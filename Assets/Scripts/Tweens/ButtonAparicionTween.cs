using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonAparicionTween : MonoBehaviour
{
    [SerializeField] private RectTransform[] buttons;
    [SerializeField] private float timeBetween = 0.1f;
    [SerializeField] private float tweenTime = 0.5f;

    void Start()
    {
        foreach (var btn in buttons)
        {
            btn.anchoredPosition = new Vector2(-600f, btn.anchoredPosition.y);
        }

        Sequence sq = DOTween.Sequence();

        for (int i = 0; i < buttons.Length; i++)
        {
            RectTransform btn = buttons[i];
            Image img = buttons[i].GetComponent<Image>();

            sq.Insert(
                i * timeBetween,
                btn.DOAnchorPos(Vector2.zero, tweenTime).SetEase(Ease.OutExpo)
            );
            sq.Insert(
                i * timeBetween,
                img.DOFade(1f, tweenTime).SetEase(Ease.OutExpo)
            );
        }
    }
}
