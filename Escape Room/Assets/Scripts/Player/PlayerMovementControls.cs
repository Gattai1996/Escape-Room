using UnityEngine;

public class PlayerMovementControls : MonoBehaviour
{
    private CharacterController characterController;
    private float speed = 5f;
    private bool hasPuzzleActive;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!hasPuzzleActive)
        {
            HandleMovementControls();
        }
    }

    private void HandleMovementControls()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * xMovement + transform.forward * zMovement;
        movement *= speed * Time.deltaTime;

        characterController.Move(movement);
    }

    public void DesativateMovements()
    {
        hasPuzzleActive = true;
    }

    public void ActivateMovements()
    {
        hasPuzzleActive = false;
    }
}
