using UnityEngine;
using UnityEngine.SceneManagement;

public class PcObject : InteractuableObject
{
    //[SerializeField] GameObject pantalla;

    public override void Interact()
    {
        GameController.Instance.isCameraFixed = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("PruebaOrdenador");


        /*if (!pantalla)
        {
            pantalla.SetActive(true);
        }*/

    }




    public override void QuitarResalte()
    {

    }

    public override void Resaltar()
    {

    }

}
