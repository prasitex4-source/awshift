using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneObject : InteractuableObject
{
    public override void Interact()
    {
        GameController.Instance.isCameraFixed = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("TelefonoPrueba");


        /*if (!pantalla)
        {
            pantalla.SetActive(true);
        }*/

    }


    public override void Resaltar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 10f);
    }

    public override void QuitarResalte()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }
}
