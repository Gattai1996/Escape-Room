using UnityEngine;

public class MouseControls : MonoBehaviour
{
    private float _mouseSensitivity = 300f;
    public float MouseSensitivity { get => _mouseSensitivity; private set { } }
    private Transform _playerBody;
    private float _xRotation;
    private bool _hasHUDObjectActive;
    private Animator _animator;

    void Start()
    {
        _playerBody = transform.parent;
        ActivateMouseControls();
        _animator = GetComponent<Animator>();
        _hasHUDObjectActive = true;
    }

    void Update()
    {
        if (!_hasHUDObjectActive)
        {
            HandleMouseControls();
        }
    }

    private void HandleMouseControls()
    {
        float mouseXAxis = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseYAxis = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseYAxis;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseXAxis);
    }

    public void DesactivateMouseControls()
    {
        _hasHUDObjectActive = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ActivateMouseControls()
    {
        _hasHUDObjectActive = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DesactivateAnimator()
    {
        _animator.enabled = false;
        _hasHUDObjectActive = false;
    }
}
