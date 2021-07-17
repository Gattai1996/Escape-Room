using System.Collections.Generic;
using UnityEngine;

public abstract class HUDObjectsManager : MonoBehaviour
{
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

    protected void SetupList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _objectsList.Add(transform.GetChild(i).gameObject);
        }
    }

    public void SetObjectToActive(int objectIndex)
    {
        GameObject objectToActive = _objectsList[objectIndex - 1];
        objectToActive.SetActive(true);
        _activeObject = objectToActive;
    }

    private void Update()
    {
        if (HaveObjectActive && Input.GetKeyDown(KeyCode.Escape))
        {
            _activeObject.SetActive(false);
            _activeObject = null;
        }
    }
}
