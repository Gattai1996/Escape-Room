using UnityEngine;
using System;

public class PlayerInteractionControls : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private float interactionDistance = 3f;
    private Camera _cam;
    private KeyCode interactKey = KeyCode.E;

    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    void Update()
    {
        Interact();
    }

    private void Interact()
    {
        Ray ray = _cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, interactionDistance, layerMask))
        {
            Interactable interactable = raycastHit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                HandleInteraction(interactable);
                HUDManager.Singleton.ShowInteractionText(interactable.Information);
            }
        }
        else
        {
            HUDManager.Singleton.HideInteractionText();
        }
    }

    private void HandleInteraction(Interactable interactable)
    {
        switch (interactable.Type)
        {
            case InteractionType.Interact:
                {
                    if (Input.GetKeyDown(interactKey))
                    {
                        interactable.Interact();
                    }
                    break;
                }
            case InteractionType.Read:
                {
                    if (!ReadablesManager.Singleton.HaveObjectActive && Input.GetKeyDown(interactKey))
                    {
                        interactable.Interact();
                    }
                    break;
                }
            case InteractionType.Puzzle:
                {
                    if (!PuzzlesManager.Singleton.HaveObjectActive && Input.GetKeyDown(interactKey))
                    {
                        interactable.Interact();
                    }
                    break;
                }
            default:
                {
                    throw new Exception(
                        $"Interactable '{interactable}' of Type '{interactable.Type}' need to be implemented on class {nameof(PlayerInteractionControls)}!"
                        );
                }
        }
    }
}
