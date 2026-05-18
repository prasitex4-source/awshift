using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class NotificacionesTween : MonoBehaviour
{
    [Header("Config UI")]
    [SerializeField] private GameObject prefabNotification;
    [SerializeField] private RectTransform contenedor;
    [SerializeField] private float timeTweens = 0.5f;
    [SerializeField] private int maxNotificaction = 3;
    [SerializeField] private float vidaNotificacion = 3.0f;

    private List<RectTransform> _activas = new List<RectTransform>();
    private const float Separation = 90f;

    public void Mostrar(string message)
    {
        // 1. LIMITE CON FADEOUT (Expulsión por abajo)
        if (_activas.Count >= maxNotificaction)
        {
            RectTransform antigua = _activas[_activas.Count - 1];
            _activas.Remove(antigua);

            // Obtenemos el Canvas Group para el Fade
            CanvasGroup cgAntigua = antigua.GetComponent<CanvasGroup>();

            antigua.DOKill();

            // Usamos una Sequence para hacer el movimiento y el fade a la vez
            Sequence sLimite = DOTween.Sequence();
            sLimite.Join(antigua.DOAnchorPos(antigua.anchoredPosition + Vector2.down * 100f, 0.4f).SetEase(Ease.InQuad));
            
            // Si el prefab tiene Canvas Group, hacemos fadeout
            if (cgAntigua != null)
            {
                sLimite.Join(cgAntigua.DOFade(0f, timeTweens)); 
            }

            sLimite.OnComplete(() => {
                if (antigua != null) Destroy(antigua.gameObject);
            });
        }

        // 2. DESPLAZAMIENTO HACIA ABAJO
        for (int i = 0; i < _activas.Count; i++)
        {
            _activas[i].DOAnchorPos(_activas[i].anchoredPosition + Vector2.down * Separation, 0.3f)
                .SetEase(Ease.OutQuad);
        }

        // 3. CREACIÓN
        GameObject go = Instantiate(prefabNotification, contenedor);
        RectTransform rt = go.GetComponent<RectTransform>();
        CanvasGroup cgNueva = go.GetComponent<CanvasGroup>(); // Obtenemos el CG de la nueva

        go.transform.SetAsLastSibling();

        // Posición inicial y Alpha inicial (si queremos que entre apareciendo)
        rt.anchoredPosition = new Vector2(400f, 0f); 
        
        // Opcional: Que aparezca de la nada (Fade In)
        if (cgNueva != null)
        {
            cgNueva.alpha = 0f;
            cgNueva.DOFade(1f, timeTweens).SetEase(Ease.OutQuad);
        }

        _activas.Insert(0, rt); 

        go.GetComponentInChildren<TextMeshProUGUI>().text = message;

        // 4. ENTRADA (Hacia arriba)
        rt.DOAnchorPos(Vector2.zero, timeTweens).SetEase(Ease.OutExpo);

        // 5. SALIDA NATURAL CON FADEOUT (A los 3 segundos)
        DOVirtual.DelayedCall(vidaNotificacion, () => 
        {
            if (rt != null && _activas.Contains(rt))
            {
                _activas.Remove(rt);
                
                CanvasGroup cgSalida = rt.GetComponent<CanvasGroup>();
                
                Sequence sSalida = DOTween.Sequence();
                // Movimiento final suave hacia abajo
                sSalida.Join(rt.DOAnchorPos(rt.anchoredPosition + Vector2.down * 80f, 0.5f).SetEase(Ease.InQuad));
                
                // Fadeout de todo el objeto
                if (cgSalida != null)
                {
                    sSalida.Join(cgSalida.DOFade(0f, 0.5f));
                }

                sSalida.OnComplete(() => {
                    if (go != null) Destroy(go);
                });
            }
        }).SetTarget(rt);
    }

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Mostrar("Notificación: " + Random.Range(10, 99));
        }
    }
}