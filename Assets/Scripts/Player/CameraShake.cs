using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    [SerializeField] private Transform cam;

    [Header("Progressive Shake")]
    [SerializeField] private float maxIntensity = 0.15f;
    [SerializeField] private float buildUpSpeed = 0.02f;
    [SerializeField] private float shakeSpeed = 3f;

    [Header("Nuclear Impact Shake")]
    [SerializeField] private float impactIntensity = 0.5f;
    [SerializeField] private float impactDuration = 2f;
    [SerializeField] private float impactSpeed = 25f;

    private Vector3 originalPos;

    private bool progressiveShake = false;
    private bool impactShake = false;

    private float currentIntensity = 0f;

    private Coroutine impactRoutine;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originalPos = cam.localPosition;
    }

    // =========================
    // PROGRESSIVE SHAKE
    // =========================

    public void StartProgressiveShake()
    {
        progressiveShake = true;
    }

    public void StopProgressiveShake()
    {
        progressiveShake = false;
        currentIntensity = 0f;

        cam.localPosition = originalPos;
    }

    // =========================
    // NUCLEAR IMPACT SHAKE
    // =========================

    public void NuclearImpact()
    {
        if (impactRoutine != null)
            StopCoroutine(impactRoutine);

        impactRoutine = StartCoroutine(NuclearImpactCoroutine());
    }

    IEnumerator NuclearImpactCoroutine()
    {
        impactShake = true;

        float timer = 0f;

        while (timer < impactDuration)
        {
            timer += Time.deltaTime;

            // Fade out suave
            float strength = Mathf.Lerp(
                impactIntensity,
                0f,
                timer / impactDuration
            );

            float time = Time.time * impactSpeed;

            float x = Mathf.PerlinNoise(time, 0f) - 0.5f;
            float y = Mathf.PerlinNoise(0f, time) - 0.5f;

            Vector3 offset =
                new Vector3(x, y, 0f) * strength;

            cam.localPosition = originalPos + offset;

            yield return null;
        }

        impactShake = false;

        // Recupera posición
        cam.localPosition = originalPos;
    }

    // =========================
    // UPDATE
    // =========================

    private void Update()
    {
        // Si hay impacto nuclear,
        // tiene prioridad absoluta
        if (impactShake)
            return;

        if (!progressiveShake)
            return;

        // Build up gradual
        currentIntensity += buildUpSpeed * Time.deltaTime;

        currentIntensity = Mathf.Clamp(
            currentIntensity,
            0,
            maxIntensity
        );

        float time = Time.time * shakeSpeed;

        float x = Mathf.PerlinNoise(time, 0f) - 0.5f;
        float y = Mathf.PerlinNoise(0f, time) - 0.5f;

        Vector3 offset =
            new Vector3(x, y, 0f) * currentIntensity;

        cam.localPosition = originalPos + offset;
    }
}