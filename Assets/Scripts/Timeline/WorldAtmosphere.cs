using UnityEngine;
using UnityEngine.Rendering;

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
        RenderSettings.skybox.SetColor("_Tint", nuclearSky);

        sunLight.intensity = 4f;
        sunLight.color = Color.white;

        RenderSettings.ambientLight = Color.red;

        exposure = 3f;
        bloom = 2f;
        vignette = 0.4f;
    }

    public void Dream()
    {
        RenderSettings.skybox.SetColor("_Tint", dreamSky);

        sunLight.intensity = 0.8f;
        sunLight.color = new Color(0.9f, 0.7f, 1f);

        RenderSettings.ambientLight = dreamAmbient;

        exposure = 1.2f;
        bloom = 1.5f;
        vignette = 0.3f;
    }
    public void White()
    {
        RenderSettings.skybox.SetColor("_Tint", whiteSky);

        sunLight.intensity = 10f;
        sunLight.color = Color.white;

        RenderSettings.ambientLight = Color.white;

        exposure = 10f;
        bloom = 5f;
        vignette = 0f;
    }
}
