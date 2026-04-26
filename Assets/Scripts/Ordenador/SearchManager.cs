using Unity.VisualScripting;
using UnityEngine;

public class SearchManager : MonoBehaviour
{
    [SerializeField] GameObject escritorio;

    [SerializeField] GameObject Error;

    public void Search()
    {
        this.gameObject.SetActive(false);
        Error.SetActive(true);
    
    }

    public void OnCrossPress()
    {
        this.gameObject.SetActive(false);
        escritorio.SetActive(true);

    }
}
