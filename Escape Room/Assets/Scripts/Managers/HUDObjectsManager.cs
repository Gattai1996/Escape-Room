using System.Collections.Generic;
using UnityEngine;

public abstract class HUDObjectsManager : MonoBehaviour
{
    protected abstract Event OnDesactivateEvent { get; }
    private List<GameObject> _objectsList = new List<GameObject>();
    private GameObject _activeObject;
    public bool HaveObjectActive { 
        get 
        { 
            if (_activeObject != null)
            {
                return true;
            }

            return false;
        } 
    }

    private void Update()
    {
        CheckInput();
    }

    protected void SetupList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _objectsList.Add(transform.GetChild(i).gameObject);
        }
    }

    private void CheckInput()
    {
        if (HaveObjectActive && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)))
        {
            SetObjectToDesactive();
        }
    }

    public void SetObjectToActive(int objectIndex)
    {
        GameObject objectToActive = _objectsList[objectIndex - 1];
        objectToActive.SetActive(true);
        _activeObject = objectToActive;
    }

    public virtual void SetObjectToDesactive()
    {
        _activeObject.SetActive(false);
        _activeObject = null;
        OnDesactivateEvent.TriggerEvent();
    }
}
