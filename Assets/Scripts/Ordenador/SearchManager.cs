using UnityEngine;

public class SearchManager : MonoBehaviour
{
    [SerializeField] GameObject optA;
    [SerializeField] GameObject optB; 
    [SerializeField] GameObject optC;
    [SerializeField] GameObject optD;

    public void OnA()
    {
        optA.gameObject.SetActive(true);

    }

    public void OnB()
    {
        optB.gameObject.SetActive(true);

    }

    public void OnC()
    {
        optC.gameObject.SetActive(true);

    }

    public void OnD()
    {
        optD.gameObject.SetActive(true);

    }

    public void OnBack()
    {
        optA.gameObject.SetActive(false);
        optB.gameObject.SetActive(false);
        optC.gameObject.SetActive(false);
        optD.gameObject.SetActive(false);
    }
    public void OnCrossPress()
    {
        this.gameObject.SetActive(false);

    }
}
