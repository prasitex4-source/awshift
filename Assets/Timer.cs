using DG.Tweening;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    [SerializeField] public int maxTime;
    private float timeInSecond;
    private float currentTime;
    private bool BossCalled = false;
    private bool pajarilloUno = false;
    private bool pajarilloDos = false;

    void Awake()
    {

        //timeInSecond = maxTime * 60;   // LUEGO CAMBIAR MAXTIMES POR TIMEINSECOND :)))))
        currentTime = maxTime;
        instance = this;
        pajarilloUno = false;
        pajarilloDos = false;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            GameController.Instance.LoadCurrentScene();
            currentTime = maxTime;
            pajarilloUno = false;
            pajarilloDos = false;
        }
        else if (currentTime <= 20 && !pajarilloUno)
        {
            BossCalled = true;
            pajarillo_script.Instance.UhOh();
            pajarilloUno = true;
        }
        else if (currentTime <= 10 && !pajarilloDos)
        {
            BossCalled = true;
            pajarillo_script.Instance.TestTwo();
            pajarilloDos = true;
        }
    }

}
