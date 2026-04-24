using Microsoft.Unity.VisualStudio.Editor;
using DG.Tweening;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    [SerializeField] public int maxTime;
    private float timeInSecond;
    private float currentTime;
    private bool BossCalled = false;

    void Awake()
    {

        //timeInSecond = maxTime * 60;   // LUEGO CAMBIAR MAXTIMES POR TIMEINSECOND :)))))
        currentTime = maxTime;
        instance = this;

    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            GameController.Instance.RestartLevel();
            currentTime = maxTime;
        }
        else if (currentTime <= 3 && !BossCalled)
        {
            BossCalled = true;
            GameController.Instance.CallBos();
        }
    }

}
