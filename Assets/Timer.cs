using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    [Header("Time Events")]
    [SerializeField] public int maxTime;
    [SerializeField] public float pajarilloFirstEvent = 10f;
    [SerializeField] public float pajarilloSecondtEvent = 20f;
    [SerializeField] public float pajarilloThirdEvent = 30f;
    [SerializeField] public float pajarilloForthEvent = 40f;
    private float currentTime;

    public event System.Action OnTimerEnd;

    private List<TimedEvents> events = new List<TimedEvents>();
    private List<TimedEvents> pendingEvents;



    void Awake()
    {
        instance = this;
        SetUpEvents();
        ResetTimer();
    }

    public void SetUpEvents()
    {
        events.Add(new TimedEvents(pajarilloSecondtEvent, () => pajarillo_script.Instance.UhOh()));
        events.Add(new TimedEvents(pajarilloFirstEvent, () => pajarillo_script.Instance.TestTwo()));

    }

    public void ResetTimer()
    {
        currentTime = maxTime;
        pendingEvents = new List<TimedEvents>(events);
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        for (int i = pendingEvents.Count - 1; i >= 0; i--)
        {
            if (currentTime <= pendingEvents[i].triggerTime)
            {
                pendingEvents[i].action.Invoke();
                pendingEvents.RemoveAt(i);
            }
        }

        if (currentTime <= 0)
        {
            OnTimerEnd?.Invoke();
            ResetTimer();
        }
    }

    public float GetTime()
    {
        return currentTime;
    }

}

public class TimedEvents
{
    public float triggerTime;
    public System.Action action;
    public TimedEvents(float time, System.Action callback)
    {
        triggerTime = time;
        action = callback;
    }
}