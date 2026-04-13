using UnityEngine;
using UnityEngine.SceneManagement;

public class PcObject : InteractuableObject
{
    [SerializeField] GameObject pantalla;

    public override void Interact()
    {
        GameController.Instance.isCameraFixed = true;
        Cursor.lockState = CursorLockMode.Confined;
        //SceneManager.LoadScene("PruebaOrdenador");


            Camera.main.transform.rotation = new Quaternion(0,0,0,0);
            pantalla.SetActive(true);
    

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
