using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    [SerializeField] private Transform cam;

    [Header("Shake Settings")]
    [SerializeField] private float maxIntensity = 0.15f;
    [SerializeField] private float buildUpSpeed = 0.02f;
    [SerializeField] private float shakeSpeed = 3f;

    private Vector3 currentOffset;
    private Vector3 velocity;

    private Vector3 originalPos;

    private bool shaking = false;
    private float currentIntensity = 0f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        originalPos = cam.localPosition;
    }

    public void StartProgressiveShake()
    {
        shaking = true;
    }

    public void StopShake()
    {
        shaking = false;
        currentIntensity = 0f;
        cam.localPosition = originalPos;
    }

    private void Update()
    {
        if (!shaking) return;

        // La intensidad aumenta poco a poco
        currentIntensity += buildUpSpeed * Time.deltaTime;
        currentIntensity = Mathf.Clamp(currentIntensity, 0, maxIntensity);

        // Movimiento orgánico usando Perlin Noise
        float time = Time.time * shakeSpeed;

        float x = Mathf.PerlinNoise(time, 0f) - 0.5f;
        float y = Mathf.PerlinNoise(0f, time) - 0.5f;

        Vector3 offset = new Vector3(x, y, 0f) * currentIntensity;

        cam.localPosition = originalPos + offset;
    }
}