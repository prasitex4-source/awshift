using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    [SerializeField] public float mouseSensX = 100.0f;
    [SerializeField] public float mouseSensY = 100.0f;

    [SerializeField] public float maxRotationX = 80.0f;
    [SerializeField] public float maxRotationY = 80.0f;

    private float rotationX;
    private float rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnLookX(InputAction.CallbackContext value)
    {
        float deltaX = value.ReadValue<float>() * mouseSensX * Time.deltaTime;
        rotationY += deltaX;
        rotationY = Mathf.Clamp(rotationY, -maxRotationY, maxRotationY);
        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);
    }

    public void OnLookY(InputAction.CallbackContext value)
    {
        /*float deltaX = value.ReadValue<float>() * mouseSensX * Time.deltaTime;
        rotationY += deltaX;
        rotationY = Mathf.Clamp(rotationY, -maxRotationY, maxRotationY);
        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);*/
    }
}
