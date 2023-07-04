using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners;

    /// <summary>
    /// Adds the listener
    /// </summary>
    /// <param name="listener"></param>
    public void Add(GameEventListener listener) => _listeners.Add(listener);
    /// <summary>
    /// removes the listener
    /// </summary>
    /// <param name="listener"></param>
    public void Remove(GameEventListener listener) => _listeners.Remove(listener);

    /// <summary>
    /// Invoke the game event
    /// </summary>
    public void Invoke()
    {
        foreach(var listener in _listeners)
        {
            listener.Invoke();
        }
    }
}
