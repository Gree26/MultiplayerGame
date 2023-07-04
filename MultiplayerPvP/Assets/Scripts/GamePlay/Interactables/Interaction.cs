using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Holds information such as name and resources required for this interaction
/// Triggers a Unity event, to which anything can listen by hooking it up in the inspector
/// </summary>
[System.Serializable]
public class Interaction
{
    [SerializeField]
    private string interactionName;

    [SerializeField]
    private UnityEvent OnInteractionDone;

    public bool isBlocked;

    //[SerializeField]
    


    //public void Interact(ItemBase payment = null)
    //{
    //    ItemStack itemPayed;
//
   //     if (paymentOptions.Count == 0 || payment == null)
  //          itemPayed = null;
    //    else if (paymentOptions.Count == 1)
    //        itemPayed = paymentOptions[0];
     //   else
    //    {
    //        itemPayed = paymentOptions.Find(p => p.ItemBase == payment);
//
     //       if (itemPayed == null)
      //          Debug.LogError("Tried to pay with " + payment + " which is not an option");
      // }


     //   OnInteraction.Invoke(itemPayed);

      //  OnInteractionDone?.Invoke();

    //}
}