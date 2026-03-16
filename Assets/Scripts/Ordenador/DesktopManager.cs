using UnityEngine;

public class DesktopManager : MonoBehaviour
{
    [SerializeField] GameObject trash;
    [SerializeField] GameObject mail;
    [SerializeField] GameObject search;

    public void OnTrashPress()
    {
        trash.SetActive(true);

    }

    public void OnSearchPress()
    {
        search.SetActive(true);

    }

    public void OnMailPress()
    {
        mail.SetActive(true);

    }
}
