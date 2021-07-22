using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlidePiece : MonoBehaviour, IPointerClickHandler
{
    private const float MOVEMENT_TIME = 0.5f;
    private float distance;
    private Transform slot;
    private Vector3 lastPosition;
    private bool moveImage;
    private Vector3 targetPosition;
    [SerializeField] private Event _movedSlidePieceEvent;
    [SerializeField] private int _pieceNumber;
    [SerializeField] private int _initialPosition;
    public Vector3 CorrectPosition { get; private set; }

    private void Start()
    {
        slot = GameObject.FindWithTag("Slot").transform;
        CorrectPosition = GameObject.Find($"Reference Point ({_pieceNumber})").transform.position;
        transform.position = GameObject.Find($"Reference Point ({_initialPosition})").transform.position;
        Vector2 referencePoint1 = GameObject.Find("Reference Point (1)").transform.position;
        Vector2 referencePoint2 = GameObject.Find("Reference Point (2)").transform.position;
        distance = Mathf.CeilToInt(Vector2.Distance(referencePoint1, referencePoint2));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        if (IsCloseToSlot())
        {
            lastPosition = transform.position;
            targetPosition = slot.position;
            slot.position = lastPosition;
            StartCoroutine(TriggerEvent());
        }
    }

    private bool IsCloseToSlot()
    {
        return Vector3.Distance(transform.position, slot.position) - distance < 10f;
    }

    private IEnumerator TriggerEvent()
    {
        moveImage = true;
        yield return new WaitForSeconds(MOVEMENT_TIME);
        _movedSlidePieceEvent.TriggerEvent();
    }

    private void Update()
    {
        if (moveImage)
        {
            transform.position = Vector3.Slerp(transform.position, targetPosition, MOVEMENT_TIME);
            if (transform.position == targetPosition)
            {
                moveImage = false;
            }
        }
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
        targetPosition = position;
    }
}
