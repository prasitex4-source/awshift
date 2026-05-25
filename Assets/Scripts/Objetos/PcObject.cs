using UnityEngine;

public class PcObject : InteractuableObject
{
    [SerializeField] GameObject pantalla;
    [SerializeField] private float thickness;
    [SerializeField] private Transform camPos;

    private Vector3 originalCamPos;
    private Quaternion originalCamRot;
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;

        originalCamPos = cam.transform.position;
        originalCamRot = cam.transform.rotation;
    }

    public override void Interact()
    {
        GameController.Instance.isCameraFixed = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        cam.transform.position = camPos.position;
        cam.transform.rotation = camPos.rotation;

        pantalla.SetActive(true);
    }

    public override void ExitInteract()
    {
        GameController.Instance.isCameraFixed = false;

        cam.transform.position = originalCamPos;
        cam.transform.rotation = originalCamRot;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void Resaltar()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", thickness);
    }

    public override void QuitarResalte()
    {
        GetComponent<Renderer>().material.SetFloat("_outliner_thickness", 0f);
    }
}