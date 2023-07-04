using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "GameEvent")]
public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent _event;
    [SerializeField] private UnityEvent _response;

    private void OnEnable() => _event.Add(this);
    private void OnDisable() => _event.Remove(this);

    /// <summary>
    /// Invoke the game event
    /// </summary>
    public void Invoke() => _response.Invoke();
}
