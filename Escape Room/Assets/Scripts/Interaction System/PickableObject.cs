using UnityEngine;

public class PickableObject : Interactable
{
    [SerializeField] private AudioClip _soundOnFall;
    private AudioSource _objectAudioSource;
    public override InteractionType Type => InteractionType.Pickup;
    public override string Information => $"Press E to pickup {gameObject.name}";

    private void Start()
    {
        _objectAudioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        PickupControls.Singleton.PickupItem(transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _objectAudioSource.PlayOneShot(_soundOnFall);
    }
}
