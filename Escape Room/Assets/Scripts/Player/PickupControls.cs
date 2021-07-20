using UnityEngine;

public class PickupControls : MonoBehaviour
{
    public static PickupControls Singleton { get; private set; }
    private Transform _itemContainer;
    public PickableObject ObjectHolding { get; private set; }
    public bool IsHoldingItem { get; private set; }
    private int _dropForce = 3;
    private Vector3 _holdedItemScale;

    void Start()
    {
        Singleton = this;
        _itemContainer = transform.GetChild(0);
    }

    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Q) && IsHoldingItem)
        {
            DropItem();
        }
    }

    public void PickupItem(Transform item)
    {
        if (IsHoldingItem)
        {
            DropItem();
        }

        item.SetParent(_itemContainer);
        item.localPosition = Vector3.zero;
        item.localRotation = Quaternion.Euler(Vector3.zero);
        _holdedItemScale = item.localScale;
        item.localScale = _holdedItemScale / 2f;
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        ObjectHolding = item.GetComponent<PickableObject>();
        IsHoldingItem = true;
    }

    private void DropItem()
    {
        Transform item = _itemContainer.GetChild(0);
        item.SetParent(null);
        item.GetComponent<Collider>().enabled = true;
        item.localScale = _holdedItemScale;
        Rigidbody itemRigidbody = item.GetComponent<Rigidbody>();
        itemRigidbody.isKinematic = false;
        itemRigidbody.AddForce(transform.forward * _dropForce, ForceMode.Impulse);
        ObjectHolding = null;
        IsHoldingItem = false;
    }
}
