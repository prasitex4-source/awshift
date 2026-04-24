using UnityEngine;
using UnityEngine.SceneManagement;

public class PcObject : InteractuableObject
{
    [SerializeField] GameObject pantalla;

    public override void Interact()
    {
        GameController.Instance.isCameraFixed = true; // hacer zoom en el ordenador en vez de lockear?????
        Cursor.lockState = CursorLockMode.Confined;
        //SceneManager.LoadScene("PruebaOrdenador");


            Camera.main.transform.rotation = new Quaternion(0,0,0,0);
            // Camera.main.transform.position.z = 
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

    public override void ExitInteract()
    {
        GameController.Instance.isCameraFixed = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

}
