using UnityEngine;
using System;

public class PlayerInteractionControls : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private float interactionDistance = 5f;
    private Camera _cam;
    private KeyCode interactKey = KeyCode.E;
    private bool hasHUDObjectActive;

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

        if (!hasHUDObjectActive && Physics.Raycast(ray, out raycastHit, interactionDistance, layerMask))
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
                    if (!PickupControls.Singleton.IsHoldingItem && Input.GetKeyDown(interactKey))
                    {
                        interactable.Interact();
                    }
                    break;
                }
            case InteractionType.Read:
                {
                    if (!PickupControls.Singleton.IsHoldingItem && !ReadablesManager.Singleton.HaveObjectActive && Input.GetKeyDown(interactKey))
                    {
                        interactable.Interact();
                    }
                    break;
                }
            case InteractionType.Puzzle:
                {
                    if (!PickupControls.Singleton.IsHoldingItem && !PuzzlesManager.Singleton.HaveObjectActive && Input.GetKeyDown(interactKey))
                    {
                        interactable.Interact();
                    }
                    break;
                }
            case InteractionType.Pickup:
                {
                    if (Input.GetKeyDown(interactKey))
                    {
                        interactable.Interact();
                    }
                    break;
                }
            case InteractionType.Combinable:
                {
                    if (Input.GetKeyDown(interactKey))
                    {
                        if (PickupControls.Singleton.IsHoldingItem)
                        {
                            interactable.Interact();
                        }
                        else
                        {
                            HUDManager.Singleton.ShowMessageText(interactable.GetComponent<CombinableObject>().ExtraInformation, 3f);
                        }
                    }
                    break;
                }
            case InteractionType.Door:
                {
                    if (!PickupControls.Singleton.IsHoldingItem && Input.GetKeyDown(interactKey))
                    {
                        interactable.Interact();
                    }
                    break;
                }
            case InteractionType.Forniture:
                {
                    if (!PickupControls.Singleton.IsHoldingItem && Input.GetKeyDown(interactKey))
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

    public void ActivateInteractions()
    {
        hasHUDObjectActive = false;
    }

    public void DesactivateInteractions()
    {
        hasHUDObjectActive = true;
    }
}
