using UnityEngine;

public class DesktopManager : MonoBehaviour
{
    [SerializeField] GameObject mail;
    [SerializeField] GameObject search;

    [SerializeField] GameObject escritorio;

    public void OnDesktopOn()
    {
        escritorio.SetActive(true);
    }


    public void OnSearchPress()
    {
        escritorio.SetActive(false);
        search.SetActive(true);

    }

    public void OnMailPress()
    {
        escritorio.SetActive(false);
        mail.SetActive(true);
        mail.GetComponent<CorreoUIController>().OpenCorreo();
    }
}
