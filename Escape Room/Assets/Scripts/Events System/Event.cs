using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Game Event", order = 0)]
public class Event : ScriptableObject
{
    private List<EventListener> _eventListeners = new List<EventListener>();
    public List<EventListener> EventListenersList => _eventListeners;
    
    public void Register(EventListener eventListener)
    {
         _eventListeners.Add(eventListener);
    }

    public void Unregister(EventListener eventListener)
    {
        _eventListeners.Remove(eventListener);
    }

    public void TriggerEvent()
    {
        foreach (EventListener eventListener in _eventListeners)
        {
            eventListener.OnTriggerEvent();
        }
    }
}
