using UnityEngine;

public class MailManager : MonoBehaviour
{

    [SerializeField] GameObject inbox;
    [SerializeField] GameObject trash;
    [SerializeField] GameObject write;

    [SerializeField] GameObject spam;

    [SerializeField] GameObject escritorio;

    public void OnTrashPress()
    {
        write.gameObject.SetActive(false);
        inbox.gameObject.SetActive(false);

        trash.gameObject.SetActive(true);
    }

    public void OnInboxPress()
    {
        write.gameObject.SetActive(false);
        trash.gameObject.SetActive(false);

        inbox.gameObject.SetActive(true);
    }

    public void OnWritePress()
    {
        inbox.gameObject.SetActive(false);
        trash.gameObject.SetActive(false);

        write.gameObject.SetActive(true);
    }

    public void OnSpamPress()
    {
        write.gameObject.SetActive(false);
        inbox.gameObject.SetActive(false);

        spam.gameObject.SetActive(true);
    }

    public void OnCrossPress()
    {
        this.gameObject.SetActive(false);
        escritorio.SetActive(true);

    }
}
