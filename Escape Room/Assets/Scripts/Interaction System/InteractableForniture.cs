using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableForniture : Interactable
{
    [SerializeField] private AudioClip _openingSound;
    [SerializeField] private AudioClip _closingSound;
    private Animator _fornitureAnimator;
    private AudioSource _furnitureAudioSource;
    private bool _isOpened;
    public override InteractionType Type => InteractionType.Forniture;

    public override string Information => PickupControls.Singleton.IsHoldingItem
        ? $"Can not use {PickupControls.Singleton.ObjectHolding.name} here, press Q to drop it"
        : $"Press E to open {gameObject.name}";

    private void Start()
    {
        _fornitureAnimator = GetComponent<Animator>();
        _furnitureAudioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (!_isOpened)
        {
            _fornitureAnimator.SetTrigger("Opened");
            _isOpened = true;
            _furnitureAudioSource.PlayOneShot(_openingSound);
        }
        else
        {
            _fornitureAnimator.SetTrigger("Closed");
            _isOpened = false;
            _furnitureAudioSource.PlayOneShot(_closingSound);
        }
    }
}
