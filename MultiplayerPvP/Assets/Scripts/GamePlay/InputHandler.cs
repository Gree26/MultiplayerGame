using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [HideInInspector]
    public DefaultInputActionBinding DefaultInputActionBinding;

    public static Action<Vector2> MoveInputUpdated;
    public static Action Attack;
    public static Action Dodge;
    public static Action<int> Ability;

    public static Action InventoryPressed;
    public static Action Pause;
    private static Stack<UnityEvent> cancelables;

    private void Awake()
    {
        DefaultInputActionBinding = new DefaultInputActionBinding();

        DefaultInputActionBinding.Player.Enable();
        DefaultInputActionBinding.UI.Enable();

        DefaultInputActionBinding.UI.Cancel.performed += Cancel;

        DefaultInputActionBinding.Player.Movement.performed += MoveInputed;
    }

    /// <summary>
    /// Add the given item to the stack.
    /// </summary>
    /// <param name="cancelEvent">Event to be added to the top of the stack.</param>
    public void AddCancelable(UnityEvent cancelEvent)
    {
        cancelables.Push(cancelEvent);
    }

    /// <summary>
    /// Remove the given cancelable from the stack
    /// </summary>
    /// <param name="cancelEvent">Event ot be removed from the stack.</param>
    public void RemoveCancelable(UnityEvent cancelEvent)
    {
        Queue<UnityEvent> savedStackItems = new Queue<UnityEvent>();
        while (cancelables.Count > 0)
        {
            var currentItem = cancelables.Pop();
            if (currentItem == cancelEvent)
            {
                break;
            }
            savedStackItems.Enqueue(currentItem);
        }

        while (savedStackItems.Count > 0)
        {
            cancelables.Push(savedStackItems.Dequeue());
        }
    }

    private void MoveInputed(InputAction.CallbackContext context)
    {
        StartCoroutine(MoveCoroutime());
    }

    private IEnumerator MoveCoroutime()
    {
        Vector2 InputVector = DefaultInputActionBinding.Player.Movement.ReadValue<Vector2>();
        do
        {
            InputVector = DefaultInputActionBinding.Player.Movement.ReadValue<Vector2>();
            MoveInputUpdated?.Invoke(InputVector);
            yield return null;
        } while (InputVector != Vector2.zero);
    }

    private void Cancel(InputAction.CallbackContext context)
    {
        if (cancelables.Count == 0)
        {
            Pause?.Invoke();
            return;
        }

        cancelables.Pop()?.Invoke();
    }
}
