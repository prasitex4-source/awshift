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
            GameController.Instance.LoadCurrentScene();
            currentTime = maxTime;
        }
        else if (currentTime <= 20 && !BossCalled)
        {
            BossCalled = true;
            pajarillo_script.Instance.UhOh();
        }
        else if (currentTime <= 10)
        {
            BossCalled = true;
            pajarillo_script.Instance.TestTwo();
        }
    }

}
