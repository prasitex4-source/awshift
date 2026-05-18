using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PcObject : InteractuableObject
{
    [SerializeField] GameObject pantalla;
    [SerializeField] private float thickness;
    [SerializeField] private Transform camPos;
    private Vector3 originalCamPos;

    void Awake()
    {
        originalCamPos = Camera.main.transform.position;
    }


    public override void Interact()
    {
        GameController.Instance.isCameraFixed = true; // hacer zoom en el ordenador en vez de lockear?????
        Cursor.lockState = CursorLockMode.Confined;
        //SceneManager.LoadScene("PruebaOrdenador");

        Camera.main.transform.rotation = new Quaternion(0, 0, 0, 0);
        Camera.main.transform.position = camPos.position;
        pantalla.SetActive(true);
    }


    public override void Resaltar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", thickness);
    }

    public override void QuitarResalte()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }

    public override void ExitInteract()
    {
        GameController.Instance.isCameraFixed = false;
        Camera.main.transform.position = originalCamPos;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
