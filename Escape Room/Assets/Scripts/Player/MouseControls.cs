using UnityEngine;

public class MouseControls : MonoBehaviour
{
    private float _mouseSensitivity = 300f;
    public float MouseSensitivity { get => _mouseSensitivity; private set { } }
    private Transform _playerBody;
    private float xRotation;
    private bool hasHUDObjectActive;

    void Start()
    {
        _playerBody = transform.parent;
        ActivateMouseControls();
    }

    void Update()
    {
        if (!hasHUDObjectActive)
        {
            HandleMouseControls();
        }
    }

    private void HandleMouseControls()
    {
        float mouseXAxis = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseYAxis = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseYAxis;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseXAxis);
    }

    public void DesactivateMouseControls()
    {
        hasHUDObjectActive = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ActivateMouseControls()
    {
        hasHUDObjectActive = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
