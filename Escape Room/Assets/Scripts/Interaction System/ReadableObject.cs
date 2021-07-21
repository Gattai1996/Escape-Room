using UnityEngine;

public class ReadableObject : Interactable
{
    [SerializeField] private int _readIndex;
    [SerializeField] private Event _enteredOnPuzzleEvent;
    [SerializeField] private AudioClip _soundOnRead;
    private AudioSource _audioSource;
    public override int IndexOfObjectHUD => _readIndex;
    public override InteractionType Type => InteractionType.Read;
    public override string Information => PickupControls.Singleton.IsHoldingItem
            ? $"Can not use {PickupControls.Singleton.ObjectHolding.name} here, press Q to drop it" 
            : $"Press E to read {gameObject.name}";

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        ReadablesManager.Singleton.SetObjectToActive(IndexOfObjectHUD);
        _enteredOnPuzzleEvent.TriggerEvent();
        _audioSource.PlayOneShot(_soundOnRead);
    }
}
