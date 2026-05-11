using System.Collections.Generic;
using UnityEngine;

public class pajarillo_script : MonoBehaviour
{
    public static pajarillo_script Instance;

    [SerializeField] List<GameObject> Pajarillos;
    [SerializeField] GameObject alarmLight;

    public int Pajaro_Stage;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Pajaro_Stage = 0;
    }

    public void UhOh()
    {
        Pajaro_Stage = 0;

        Cursor.lockState = CursorLockMode.Confined;

        Pajarillos[Pajaro_Stage].SetActive(true);
        alarmLight.SetActive(true);
    }

    public void TestTwo()
    {
        Pajaro_Stage = 1;

        Cursor.lockState = CursorLockMode.Confined;

        Pajarillos[Pajaro_Stage].SetActive(true);
    }

        public void HideBird()
        {
            //Debug.Log("Ocultando: " + Pajaro_Stage);

            //Pajarillos[Pajaro_Stage].SetActive(false);

            foreach(GameObject bird in Pajarillos)
            {
                bird.SetActive(false);
            }

            Cursor.lockState = CursorLockMode.Locked;
        }
}