using UnityEngine;

public class LogManager : MonoBehaviour
{
    [SerializeField] GameObject escritorio;

    [SerializeField] GameObject login;


    public void OnArrowPress()
    {
        escritorio.SetActive(true);
        login.SetActive(false); //como no volver al login, lo desactivamos y ya jeje
    }
}
