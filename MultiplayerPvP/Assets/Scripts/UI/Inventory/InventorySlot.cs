using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Meant to manage each inventory botton's image, number and if it is selected.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class InventorySlot : MonoBehaviour
    {
        public static Action<int> itemSelected;
        public static Action<int, int> swapPerformed;

        private Sprite? _itemImage = null;

        [SerializeField]
        private Image _image;

        [SerializeField]
        private Text _totalText;

        [SerializeField]
        private GameObject _selectedIcon;

        [SerializeField]
        private int _buttonId = -1;

        //-1 means none is selected
        private static int _selectedButton = -1;

        private static Action _newSelectedAction;

        private int _stack = 0;

        private void OnEnable()
        {
            _newSelectedAction += SelectedUpdated;
            Inventory.itemAdded += NewItemSelected;
            NewItemSelected();
        }

        private void OnDisable()
        {
            _newSelectedAction -= SelectedUpdated;
            Inventory.itemAdded -= NewItemSelected;
        }

        private void NewItemSelected()
        {
            _itemImage = Inventory.GetImageAtPosition(_buttonId);
            _stack = (_itemImage != null) ? Inventory.GetTotalAtPosition(_buttonId):0;

            //Debug.Log("Position: " + _buttonId + " | Item Image: " + _itemImage  + " | Total: " + _stack);

            UpdateSelectedImage();
            UpdateTotal();
        }

        private void UpdateSelectedImage()
        {
            if (_itemImage != null)
            {
                _image.gameObject.SetActive(true);
                _image.sprite = _itemImage;
            }
            else
            {
                _image.gameObject.SetActive(false);
            }
        }

        private void UpdateTotal()
        {
            if (_stack > 0)
            {
                _totalText.gameObject.SetActive(true);
                _totalText.text = _stack.ToString();
            }
            else
            {
                _totalText.gameObject.SetActive(false);
            }
        }

        private void UpdateSelectedState(int value)
        {
            bool thisObjectWasSelected = (value >= 0) && (value == _selectedButton);
            bool objectWasPreviouslySelected = (value >= 0) && (_selectedButton >= 0);
            bool thisObjectIsBeingSelected = (value >= 0) && (value == _buttonId);
            bool thisObjectIsNowSelected = (thisObjectIsBeingSelected && !(objectWasPreviouslySelected));
            var previousValue = _selectedButton;
            _selectedButton = value;
            if (thisObjectWasSelected && objectWasPreviouslySelected)
            {
                _selectedButton = -1;
            }
            else if (thisObjectWasSelected || objectWasPreviouslySelected)
            {
                swapPerformed?.Invoke(previousValue, _selectedButton);
                _selectedButton = -1;
            }
            else if (thisObjectIsNowSelected)
            {
                itemSelected?.Invoke(value);
            }
            Debug.Log("Current Selected: " + _selectedButton);
            _selectedIcon.SetActive(thisObjectIsNowSelected);
            _newSelectedAction?.Invoke();
        }

        private void SelectedUpdated()
        {
            if (_selectedButton < 0 || _selectedButton != this._buttonId)
            {
                _selectedIcon.SetActive(false);
                return;
            }
            if (_selectedButton == this._buttonId)
            {
                _selectedIcon.SetActive(true);
                return;
            }

        }

        public void ButtonSelected()
        {
            UpdateSelectedState(this._buttonId);
        }

        /// <summary>
        /// Change the number of items in this slot.
        /// </summary>
        /// <param name="numberOfItems">The new number of items.</param>
        public void NewItem(int numberOfItems) => NewItem(_itemImage, numberOfItems);

        /// <summary>
        /// Change the item that is currently in this slot and set the stack to 1.
        /// </summary>
        /// <param name="itemImage">The new item's image.</param>
        public void NewItem(Sprite? itemImage) => NewItem(itemImage, 1);

        /// <summary>
        /// Change the item image and the stack count.
        /// </summary>
        /// <param name="itemImage">New Item image</param>
        /// <param name="numberOfItems">New Stack Count</param>
        public void NewItem(Sprite? itemImage, int numberOfItems)
        {
            NewItemImage(itemImage);
            NewNumber(numberOfItems);
            UpdateFrame();
        }

        private void NewNumber(int numberOfItems)
        {
            _stack = numberOfItems;
        }

        private void NewItemImage(Sprite? itemImage)
        {
            _itemImage = itemImage;
        }

        private void UpdateFrame()
        {
            if (_itemImage == null || _stack <= 0)
            {
                _image.gameObject.SetActive(false);
                return;
            }
            _image.sprite = _itemImage;
        }
    }
}
