using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    [Header("Timer")]
    [SerializeField] private float maxTime = 60f;

    [Header("Timeline")]
    [SerializeField] private List<TimelineEvent> timelineEvents =
        new List<TimelineEvent>();

    private float elapsedTime;
    private int currentEventIndex;

    public event System.Action OnTimerEnd;

    private void Awake()
    {
        instance = this;

        // MUY IMPORTANTE:
        // Ordenamos automáticamente por tiempo
        timelineEvents.Sort((a, b) => a.time.CompareTo(b.time));

        ResetTimer();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // Ejecuta eventos pendientes
        while (
            currentEventIndex < timelineEvents.Count &&
            elapsedTime >= timelineEvents[currentEventIndex].time
        )
        {
            timelineEvents[currentEventIndex].action.Invoke();

            Debug.Log(
                $"EVENT TRIGGERED: {timelineEvents[currentEventIndex].description}"
            );

            currentEventIndex++;
        }

        // Fin del timer
        if (elapsedTime >= maxTime)
        {
            OnTimerEnd?.Invoke();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        currentEventIndex = 0;
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public float GetRemainingTime()
    {
        return maxTime - elapsedTime;
    }
}

[System.Serializable]
public class TimelineEvent
{
    [Header("Event Info")]
    public string description;

    [Header("Trigger Time")]
    public float time;

    [Header("Action")]
    public UnityEvent action;
}