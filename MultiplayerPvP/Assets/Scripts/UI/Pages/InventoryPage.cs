using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class InventoryPage : MonoBehaviour
    {
        private static CanvasGroup _thisCanvaseGroup;
        
        private void OnEnable()
        {
            _thisCanvaseGroup = this.GetComponent<CanvasGroup>();
        }

        private void OnDisable()
        {
            _thisCanvaseGroup = null;
        }

        /// <summary>
        /// Set the open state of the inventory. Meant to be used in tandem with 
        /// </summary>
        /// <param name="isInventoryOpen"></param>
        public static void Open(bool isInventoryOpen)
        {
            if (_thisCanvaseGroup == null)
            {
                return;
            }

            _thisCanvaseGroup.alpha = isInventoryOpen ? 1 : 0;
            _thisCanvaseGroup.blocksRaycasts = isInventoryOpen;
            _thisCanvaseGroup.interactable = isInventoryOpen;
        }
    }
}
