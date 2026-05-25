using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public enum GamePhase
{
    Office,
    NuclearFlash,
    Dream,
    Whiteout
}
public class WorldAtmosphere : MonoBehaviour
{
    public GamePhase phase;
    public static WorldAtmosphere instance;

    [Header("Main Light (Sun)")]
    public Light sunLight;

    [Header("Environment")]
    public Color officeSky = new Color(1f, 0.75f, 0.55f);
    public Color dreamSky = new Color(0.8f, 0.6f, 1f);
    public Color nuclearSky = Color.red;
    public Color whiteSky = Color.white;

    [Header("Ambient")]
    public Color officeAmbient = new Color(0.6f, 0.7f, 0.8f);
    public Color dreamAmbient = new Color(1f, 0.8f, 1f);

    [Header("Post FX refs")]
    public float exposure;
    public float bloom;
    public float vignette;

    [Header("Nuclear Flash Settings")]
    public float flickerDuration = 1.2f;
    public float finalBlastDuration = 2f;

    [Header("Others")]
    public float fadeDuration = 2f;

    private Coroutine currentRoutine;

    private void Awake()
    {
        instance = this;
    }

    public void SetPhase(GamePhase newPhase)
    {
        phase = newPhase;

        switch (phase)
        {
            case GamePhase.Office:
                Office();
                break;

            case GamePhase.NuclearFlash:
                NuclearFlash();
                break;

            case GamePhase.Dream:
                Dream();
                break;

            case GamePhase.Whiteout:
                White();
                break;
        }
    }

    public void Office()
    {
        RenderSettings.skybox.SetColor("_Tint", officeSky);

        sunLight.intensity = 1.5f;
        sunLight.color = new Color(1f, 0.78f, 0.55f);

        RenderSettings.ambientLight = officeAmbient;

        exposure = 0.8f;
        bloom = 0.3f;
        vignette = 0.2f;
    }

    public void NuclearFlash()
    {
        StartCoroutine(NuclearFlashCin());
    }

    IEnumerator NuclearFlashCin()
    {
        // Guardamos estado inicial
        Color initialSky = RenderSettings.skybox.GetColor("_Tint");
        Color initialAmbient = RenderSettings.ambientLight;

        float initialIntensity = sunLight.intensity;
        Color initialSunColor = sunLight.color;

        // ----------
        // FLICKER
        // ----------
        float t = 0f;

        while (t < flickerDuration)
        {
            t += Time.deltaTime;

            // Parpadeo irregular
            float flicker = Mathf.PingPong(Time.time * 25f, 1f);

            // Intensidad subiendo poco a poco
            float intensity = Mathf.Lerp(initialIntensity, 3f, t / flickerDuration);

            // Añadimos vibración/parpadeo
            sunLight.intensity = intensity + flicker * 0.8f;

            // Color ligeramente más caliente
            sunLight.color = Color.Lerp(
                initialSunColor,
                new Color(1f, 0.9f, 0.7f),
                t / flickerDuration
            );

            yield return null;
        }

        // ----------
        // BLAST
        // ----------
        t = 0f;

        while (t < finalBlastDuration)
        {
            t += Time.deltaTime;

            float lerp = t / finalBlastDuration;

            RenderSettings.skybox.SetColor(
                "_Tint",
                Color.Lerp(initialSky, nuclearSky, lerp)
            );

            RenderSettings.ambientLight = Color.Lerp(
                initialAmbient,
                Color.red,
                lerp
            );

            sunLight.intensity = Mathf.Lerp(3f, 10f, lerp);

            sunLight.color = Color.Lerp(
                new Color(1f, 0.9f, 0.7f),
                Color.white,
                lerp
            );

            // Post FX
            exposure = Mathf.Lerp(0.8f, 5f, lerp);
            bloom = Mathf.Lerp(0.3f, 3f, lerp);
            vignette = Mathf.Lerp(0.2f, 0.5f, lerp);

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        // Explosión final
        Dream();
    }

public void Dream()
{
    StartCoroutine(DreamTransition());
}

IEnumerator DreamTransition()
{
    Color startSky = RenderSettings.skybox.GetColor("_Tint");
    Color startAmbient = RenderSettings.ambientLight;

    float startIntensity = sunLight.intensity;
    Color startSunColor = sunLight.color;

    float startExposure = exposure;
    float startBloom = bloom;
    float startVignette = vignette;

    // TARGETS DREAM
    Color targetSky = new Color(1f, 0.45f, 0.25f);

    Color targetAmbient = new Color(
        1f,
        0.55f,
        0.4f
    );

    Color targetSun = new Color(
        1f,
        0.65f,
        0.35f
    );

    float targetIntensity = 2.5f;

    float targetExposure = 1.8f;
    float targetBloom = 2.2f;
    float targetVignette = 0.35f;

    float duration = 4f;

    float t = 0f;

    while (t < duration)
    {
        t += Time.deltaTime;

        float lerp = Mathf.SmoothStep(
            0f,
            1f,
            t / duration
        );

        RenderSettings.skybox.SetColor(
            "_Tint",
            Color.Lerp(startSky, targetSky, lerp)
        );

        RenderSettings.ambientLight = Color.Lerp(
            startAmbient,
            targetAmbient,
            lerp
        );

        sunLight.color = Color.Lerp(
            startSunColor,
            targetSun,
            lerp
        );

        sunLight.intensity = Mathf.Lerp(
            startIntensity,
            targetIntensity,
            lerp
        );

        exposure = Mathf.Lerp(
            startExposure,
            targetExposure,
            lerp
        );

        bloom = Mathf.Lerp(
            startBloom,
            targetBloom,
            lerp
        );

        vignette = Mathf.Lerp(
            startVignette,
            targetVignette,
            lerp
        );

        yield return null;
    }
}
public void White()
{
    StartCoroutine(WhiteTransition());
}

IEnumerator WhiteTransition()
{
    // Estado inicial (Dream)
    Color startSky = RenderSettings.skybox.GetColor("_Tint");
    Color startAmbient = RenderSettings.ambientLight;

    float startIntensity = sunLight.intensity;
    Color startSunColor = sunLight.color;

    float startExposure = exposure;
    float startBloom = bloom;
    float startVignette = vignette;

    // Estado final (Whiteout)
    Color targetSky = Color.white;
    Color targetAmbient = Color.white;
    Color targetSun = Color.white;

    float targetIntensity = 10f;
    float targetExposure = 10f;
    float targetBloom = 5f;
    float targetVignette = 0f;

    float duration = 2.5f;

    float t = 0f;

    while (t < duration)
    {
        t += Time.deltaTime;

        float lerp = Mathf.SmoothStep(0f, 1f, t / duration);

        // Skybox
        RenderSettings.skybox.SetColor(
            "_Tint",
            Color.Lerp(startSky, targetSky, lerp)
        );

        // Ambient
        RenderSettings.ambientLight = Color.Lerp(
            startAmbient,
            targetAmbient,
            lerp
        );

        // Sun
        sunLight.color = Color.Lerp(
            startSunColor,
            targetSun,
            lerp
        );

        sunLight.intensity = Mathf.Lerp(
            startIntensity,
            targetIntensity,
            lerp
        );

        // Post FX
        exposure = Mathf.Lerp(startExposure, targetExposure, lerp);
        bloom = Mathf.Lerp(startBloom, targetBloom, lerp);
        vignette = Mathf.Lerp(startVignette, targetVignette, lerp);

        yield return null;
    }

    // Clamp final (seguridad)
    RenderSettings.skybox.SetColor("_Tint", targetSky);
    RenderSettings.ambientLight = targetAmbient;
    sunLight.color = targetSun;
    sunLight.intensity = targetIntensity;

    exposure = targetExposure;
    bloom = targetBloom;
    vignette = targetVignette;

    ScreenFade.instance.FadeToWhiteStart(fadeDuration);
}
}
