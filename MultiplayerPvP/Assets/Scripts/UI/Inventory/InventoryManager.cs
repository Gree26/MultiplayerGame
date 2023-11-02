using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class InventoryManager : MonoBehaviour
    {
        private void OnEnable()
        {
            InventorySlot.swapPerformed += SwapPerformed;
            InventorySlot.itemSelected += ItemSelected;
        }

        private void OnDisable()
        {
            InventorySlot.swapPerformed -= SwapPerformed;
            InventorySlot.itemSelected -= ItemSelected;
        }

        private void SwapPerformed(int positionOne, int positionTwo)
        {
            bool successfulSwap = Inventory.SwapItems(positionOne, positionTwo);
            //return successfulSwap;
        }

        private void ItemSelected(int position)
        {
            SItem item = Inventory.GetItemAtPosition(position);

            if (position == -1 || item == null)
            {
                ItemDescriptionPage.Close();
                return;
            }

            ItemDescriptionPage.Open(Inventory.GetItemAtPosition(position));
        }
    }
}
