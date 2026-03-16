using UnityEngine;

public class LogManager : MonoBehaviour
{
    [SerializeField] GameObject escritorio;


    public void OnArrowPress()
    {
        escritorio.SetActive(true);
        this.gameObject.SetActive(false); //como no volverá al login, lo desactivamos y ya jeje
    }
}
