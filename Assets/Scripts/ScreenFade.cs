using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public static ScreenFade instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] public float startFadeDuration = 2f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // IMPORTANTE: empezar en blanco
        fadeImage.color = Color.white;

        StartCoroutine(StartFadeIn());
    }

    private IEnumerator StartFadeIn()
    {
        yield return FadeFromWhite(startFadeDuration);
    }


    // FADE TO WHITE
    public IEnumerator FadeToWhite(float duration)
    {
        float t = 0f;

        Color start = fadeImage.color;
        Color end = Color.white;

        while (t < duration)
        {
            t += Time.deltaTime;

            float lerp = t / duration;

            fadeImage.color = Color.Lerp(start, end, lerp);

            yield return null;
        }
    }

    // FADE FROM WHITE
    public IEnumerator FadeFromWhite(float duration)
    {
        float t = 0f;

        Color start = fadeImage.color;
        Color end = new Color(1, 1, 1, 0);

        while (t < duration)
        {
            t += Time.deltaTime;

            float lerp = t / duration;

            fadeImage.color = Color.Lerp(start, end, lerp);

            yield return null;
        }
    }

    // ATAJO SIMPLE
    public void FadeToWhiteStart(float duration)
    {
        StartCoroutine(FadeToWhite(duration));
    }

    public void FadeFromWhiteStart(float duration)
    {
        StartCoroutine(FadeFromWhite(duration));
    }
}