using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerGUI : MonoBehaviour
    {
        private struct InteractUiElement
        {
            private Interactable _interact;
            private GameObject _gameObject;
            public Interactable Interaction
            {
                get { return _interact; }
            }
            public GameObject Object
            {
                get { return _gameObject; }
            }
            public InteractUiElement(Interactable name, GameObject gObject)
            {
                this._interact = name;
                this._gameObject = gObject;
            }
        }

        private RectTransform canvasRectTransform;
        private Vector2 uiOffset;

        [SerializeField]
        private float _fontSize = 24f;

        private readonly string _pickupString = "PRESS X TO INTERACT";

        private List<InteractUiElement> interactionUi = new List<InteractUiElement>();

        private DefaultInputActionBinding defaultInputActionBinding;

        private string InteractKey;

        private void Awake()
        {
            this.canvasRectTransform = GetComponent<RectTransform>();
            this.uiOffset = new Vector2((float)canvasRectTransform.sizeDelta.x / 2f, (float)canvasRectTransform.sizeDelta.y / 2f);
            defaultInputActionBinding = new DefaultInputActionBinding();
            InteractKey = defaultInputActionBinding.Player.Interact.bindings[0].path;
        }

        private void Start()
        {
            Interactable.OnEnterRange += OpenInteractPopup;
            Interactable.OnExitRange += CloseInteractPopup;
        }

        private void OpenInteractPopup(Interactable interactableObject)
        {
            bool exists = false;

            foreach (var interactable in interactionUi)
            {
                if (interactable.Interaction == interactableObject)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists) 
            {
                
                interactionUi.Add(new InteractUiElement(interactableObject, interactableObject.gameObject));
            }
        }

        private void CloseInteractPopup(Interactable interactableObject)
        {
            foreach(var interactable in interactionUi)
            {
                if (interactable.Interaction == interactableObject)
                {
                    interactionUi.Remove(interactable);
                    break;
                }
            }
        }
    }
}
