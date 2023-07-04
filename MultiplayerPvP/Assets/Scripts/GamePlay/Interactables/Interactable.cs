using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public static event Action<Interactable> OnEnterRange;
    public static event Action<Interactable> OnExitRange;

    private InteractionBehavior _behavior;

    public InteractionBehavior behavior { get => _behavior; }

    // public getter so other scripts can read but not modify it
    public List<Interaction> Interactions { get => _interactions; }

    [SerializeField]
    private List<Interaction> _interactions;

    // Unity events version. Nullcheck on Invoke is not necessary since they are public
    // Assign listeners in the editor or through code (e.g. for runtime) via interactable.OnPlayerStartsLookingAt.AddListener(YourMethod);
    [SerializeField]
    private Action EnterInteractionRange;
    [SerializeField]
    private Action ExitInteractionRange;



    //public event Action OnInteractionsChanged = delegate { };


    private void Awake()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(OnEnterRange!=null)
            OnEnterRange(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (OnExitRange != null)
            OnExitRange(this);
    }

    public void InvokeInteractionsChanged()
    {
        //OnInteractionsChanged();
    }


    //public void RefreshUI(ItemStack stack)
    //{
     //   OnInteractionsChanged();
    //}

    public void BlockInteractionByIndex(int index)
    {
        //interactions[index].isBlocked = true;
    }

    public void UnblockInteractionByIndex(int index)
    {
        //interactions[index].isBlocked = false;
    }
}
