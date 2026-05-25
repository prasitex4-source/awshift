using UnityEngine;

public class Alarma_Script : MonoBehaviour
{
    [SerializeField] GameObject pantalla;
    [SerializeField] GameObject Alarm;

    public void AlarmOn()
    {
        if (!pantalla.activeSelf)
            pantalla.SetActive(true);

        if (pantalla.activeSelf)
        {
            GameController.Instance.isCameraFixed = false;

            Cursor.lockState = CursorLockMode.Locked;
        }

        Alarm.SetActive(true);
    }

    public void AlarmOff()
    {
        Alarm.SetActive(false);
    }
}
