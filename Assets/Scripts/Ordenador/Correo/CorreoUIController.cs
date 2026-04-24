using UnityEngine;

public class CorreoUIController : MonoBehaviour
{

    [SerializeField] GameObject papelera;
    [SerializeField] GameObject redactar;
    [SerializeField] GameObject inbox;
    [SerializeField] GameObject spam;

    public void ShowPapelera()
    {
        papelera.SetActive(true);
        redactar.SetActive(false);
        inbox.SetActive(false);
        spam.SetActive(false);
    }

    public void ShowRedactar()
    {
        papelera.SetActive(false);
        redactar.SetActive(true);
        inbox.SetActive(false);
        spam.SetActive(false);
    }

    public void ShowInbox()
    {
        papelera.SetActive(false);
        redactar.SetActive(false);
        inbox.SetActive(true);
        spam.SetActive(false);
    }

    public void ShowSpam()
    {
        papelera.SetActive(false);
        redactar.SetActive(false);
        inbox.SetActive(false);
        spam.SetActive(true);
    }

    public void CloseCorreo()
    {
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OpenCorreo()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    
}
