using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleTween : MonoBehaviour
{

    private Vector3 _originalPos;
    private bool hasFinishedTween = true;

    void Awake()
    {
        _originalPos = transform.position;
    }

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame && hasFinishedTween)
        {
            hasFinishedTween = false;
            transform.DOMove(new Vector3(5f, 5f, 0f) + _originalPos, 1f)
            .SetEase(Ease.InOutQuint)
            .OnComplete(() =>
            {
                hasFinishedTween = true;
            });
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame && hasFinishedTween)
        {
            hasFinishedTween = false;
            transform.DOMove(_originalPos, 1f)
            .SetEase(Ease.InOutQuint)
            .OnComplete(() =>
                {
                    hasFinishedTween = true;
                });
        }
    }
}
