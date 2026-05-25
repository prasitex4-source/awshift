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
    [SerializeField] public float cameraShake = 50f;

    [SerializeField] public float firstMail = 25f;
    private float currentTime;
    GamePhase currentPhase;

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
        
        events.Add(new TimedEvents(cameraShake, () => CameraShake.instance.StartProgressiveShake()));
    }

    public void ResetTimer()
    {
        currentTime = maxTime;
        pendingEvents = new List<TimedEvents>(events);
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        float elapsedTime = maxTime - currentTime;

        for (int i = pendingEvents.Count - 1; i >= 0; i--)
        {
            if (elapsedTime >= pendingEvents[i].triggerTime)
            {
                pendingEvents[i].action.Invoke();
                pendingEvents.RemoveAt(i);
            }
        }

        if (currentTime <= 0)
        {
            OnTimerEnd?.Invoke();

            CameraShake.instance.StopShake();

            ResetTimer();
        }

            float t = maxTime - currentTime;

        GamePhase newPhase;

        if (t < 5f)
            newPhase = GamePhase.Office;
        else if (t < 10f)
            newPhase = GamePhase.NuclearFlash;
        else if (t < 30f)
            newPhase = GamePhase.Dream;
        else
            newPhase = GamePhase.Whiteout;

        if (newPhase != currentPhase)
        {
            currentPhase = newPhase;
            WorldAtmosphere.instance.SetPhase(currentPhase);
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