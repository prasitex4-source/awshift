using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class pajarillo_script : MonoBehaviour
{
    public static pajarillo_script Instance;
    [SerializeField] private EventReference pajaroSound;

    [SerializeField] List<GameObject> Pajarillos = new List<GameObject>();
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
        AudioManager.Instance.PlaySFX(pajaroSound, transform.position, "PajaroParameter", "Enfadado");

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

            for(int i = 0; i < Pajarillos.Count; i++)
            {
                Debug.Log("Pajarillo " + i + " oculto");
                Pajarillos[i].SetActive(false);
            }

            Cursor.lockState = CursorLockMode.Locked;
        }
}