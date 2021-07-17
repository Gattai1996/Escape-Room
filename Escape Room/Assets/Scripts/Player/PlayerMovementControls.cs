using UnityEngine;

public class PlayerMovementControls : MonoBehaviour
{
    private CharacterController characterController;
    private float speed = 5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovementControls();
    }

    private void HandleMovementControls()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * xMovement + transform.forward * zMovement;
        movement *= speed * Time.deltaTime;

        characterController.Move(movement);
    }
}
