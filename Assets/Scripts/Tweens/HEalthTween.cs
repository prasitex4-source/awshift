using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.InputSystem;

public class HEalthTween : MonoBehaviour
{
    [SerializeField] Image barraBAck;
    [SerializeField] Image barraFront;
    [SerializeField] TextMeshProUGUI textoVida;
    [SerializeField] int maxVida = 100;
    [SerializeField] float timeTween = 0.5f;
    [SerializeField] float delayTime = 0.5f;

    private int _vidaActual;

    private void Awake()
    {
        _vidaActual = maxVida;
        textoVida.text = _vidaActual.ToString();
    }
    
    public void Damage(int damage)
    {
        int vidaNueva = Mathf.Max(0, _vidaActual - damage);
        float targetfill =  (float) vidaNueva / maxVida;

        barraFront.DOFillAmount(targetfill, timeTween)
            .SetEase(Ease.OutElastic);
        barraBAck.DOFillAmount(targetfill, timeTween)
            .SetDelay(delayTime).SetEase(Ease.OutElastic);

        DOTween.To(() => _vidaActual, x =>
        {
            _vidaActual = x;
            textoVida.text = _vidaActual.ToString();
        }, vidaNueva, timeTween).SetEase(Ease.OutCubic);

    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
            Damage(25);
    }

}
