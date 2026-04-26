using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneObject : InteractuableObject
{
    [SerializeField] GameObject pantalla;
    [SerializeField] GameObject newPos;
    private Vector3 originalPos;
    private Quaternion originalRot;
    
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;
    }
    public override void Interact()
    {
        GameController.Instance.isCameraFixed = true;
        Cursor.lockState = CursorLockMode.Confined;
       // SceneManager.LoadScene("TelefonoPrueba");
    

        transform.position = newPos.transform.position;
        transform.rotation = newPos.transform.rotation;
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

    public override void ExitInteract()
    {
        GameController.Instance.isCameraFixed = false;
        Cursor.lockState = CursorLockMode.Locked;
        transform.position = originalPos;
        transform.rotation = originalRot;
    }
}
