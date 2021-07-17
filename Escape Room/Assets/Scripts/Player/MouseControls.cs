using UnityEngine;

public class MouseControls : MonoBehaviour
{
    private float _mouseSensitivity = 300f;
    public float MouseSensitivity { get => _mouseSensitivity; private set { } }
    private Transform _playerBody;
    private float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerBody = transform.parent;
    }

    void Update()
    {
        HandleMouseControls();
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
}
