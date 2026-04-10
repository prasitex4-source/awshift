using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTween : MonoBehaviour
{
    private Image _img;
    private Tween _loop;

    private void Awake()
    {
        _img = GetComponent<Image>();
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            _loop = _img.DOFade(0.3f, 0.5f).SetEase(Ease.InOutCubic)
                .SetLoops(-1, LoopType.Yoyo);
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _loop?.Kill();
            _img.DOFade(1f, 0.5f).SetEase(Ease.InOutCubic);
        }

    }
}
