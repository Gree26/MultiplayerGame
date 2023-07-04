// GENERATED AUTOMATICALLY FROM 'Assets/Input/DefaultInputActionBinding.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DefaultInputActionBinding : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultInputActionBinding()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultInputActionBinding"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9237ee4b-ee20-411c-be4a-1fed6449d968"",
            ""actions"": [
                {
                    ""name"": ""PressAttack"",
                    ""type"": ""Button"",
                    ""id"": ""c20ff7c7-5854-45c7-94e5-10ad91a243ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,SlowTap""
                },
                {
                    ""name"": ""HoldAttack"",
                    ""type"": ""Button"",
                    ""id"": ""2c1ffb20-e715-49e1-8041-8dfed312f649"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c8368645-7948-43bf-97d9-637e0995a184"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""f1ff890c-b59d-4a84-9f29-0ce4431493de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""dd1509e6-efdb-43b3-9a7f-5d91d93d2be5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""38bdbc73-4d55-4c0f-9aa9-95bbb6eb3e0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fdd37918-95c9-4688-a928-16f328fd6601"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f1d612bd-ab3d-45af-b57a-2804f39a2873"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2b3f0f65-a199-4a2f-a9c2-07aa8d175b5e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a250df0c-7fa7-4c80-9f7f-c102f977234c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""105c59a9-b8b0-4dbb-a9f5-f25bfd7af7b6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""75153217-f19e-4bea-86cd-80f0a2a9d19d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03abfb9f-eff2-4704-aec5-eebd690a7fa2"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28bde42d-6c17-4084-baff-95b0883eae32"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21289817-e8fb-4f8b-9117-3abbf0c89dd2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HoldAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f944a70-0f33-490a-8e9e-8f297d9d7197"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""08b68af4-3206-418b-85ae-5704c4dc5bde"",
            ""actions"": [
                {
                    ""name"": ""DebugToggle"",
                    ""type"": ""Button"",
                    ""id"": ""66a8da8d-7a7b-482c-b8b9-347e2be2efee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""4d5e4804-996a-4f04-b1e6-a79626b66b42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""fbb85f25-047f-4d58-beb9-298cbd7a083f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""6d43dd24-c424-447a-a8c6-1c80a3c02ebd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""a523deda-0a50-45a1-9ec9-32c532b5050b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""64c2bb38-2a85-40c2-9db1-a0a324f71e40"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7567b4e2-2edd-4d2c-80f2-8a53256258f3"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a23ea6d-2bb8-4160-a2c1-b7144e88c597"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39cf0531-50be-4023-9111-60f446d3edfe"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f122874a-a362-4413-8bac-3a087163658b"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4040b5cc-aed3-4b7d-bb55-75af7eec8f28"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d007f553-d703-42c3-b952-14b87662b878"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PressAttack = m_Player.FindAction("PressAttack", throwIfNotFound: true);
        m_Player_HoldAttack = m_Player.FindAction("HoldAttack", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Dodge = m_Player.FindAction("Dodge", throwIfNotFound: true);
        m_Player_MousePos = m_Player.FindAction("MousePos", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_DebugToggle = m_UI.FindAction("DebugToggle", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Return = m_UI.FindAction("Return", throwIfNotFound: true);
        m_UI_Up = m_UI.FindAction("Up", throwIfNotFound: true);
        m_UI_Down = m_UI.FindAction("Down", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_PressAttack;
    private readonly InputAction m_Player_HoldAttack;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Dodge;
    private readonly InputAction m_Player_MousePos;
    private readonly InputAction m_Player_Interact;
    public struct PlayerActions
    {
        private @DefaultInputActionBinding m_Wrapper;
        public PlayerActions(@DefaultInputActionBinding wrapper) { m_Wrapper = wrapper; }
        public InputAction @PressAttack => m_Wrapper.m_Player_PressAttack;
        public InputAction @HoldAttack => m_Wrapper.m_Player_HoldAttack;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputAction @MousePos => m_Wrapper.m_Player_MousePos;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @PressAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressAttack;
                @PressAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressAttack;
                @PressAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressAttack;
                @HoldAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldAttack;
                @HoldAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldAttack;
                @HoldAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldAttack;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Dodge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                @MousePos.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePos;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PressAttack.started += instance.OnPressAttack;
                @PressAttack.performed += instance.OnPressAttack;
                @PressAttack.canceled += instance.OnPressAttack;
                @HoldAttack.started += instance.OnHoldAttack;
                @HoldAttack.performed += instance.OnHoldAttack;
                @HoldAttack.canceled += instance.OnHoldAttack;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_DebugToggle;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Return;
    private readonly InputAction m_UI_Up;
    private readonly InputAction m_UI_Down;
    public struct UIActions
    {
        private @DefaultInputActionBinding m_Wrapper;
        public UIActions(@DefaultInputActionBinding wrapper) { m_Wrapper = wrapper; }
        public InputAction @DebugToggle => m_Wrapper.m_UI_DebugToggle;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Return => m_Wrapper.m_UI_Return;
        public InputAction @Up => m_Wrapper.m_UI_Up;
        public InputAction @Down => m_Wrapper.m_UI_Down;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @DebugToggle.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDebugToggle;
                @DebugToggle.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDebugToggle;
                @DebugToggle.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDebugToggle;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Return.started -= m_Wrapper.m_UIActionsCallbackInterface.OnReturn;
                @Return.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnReturn;
                @Return.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnReturn;
                @Up.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_UIActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DebugToggle.started += instance.OnDebugToggle;
                @DebugToggle.performed += instance.OnDebugToggle;
                @DebugToggle.canceled += instance.OnDebugToggle;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Return.started += instance.OnReturn;
                @Return.performed += instance.OnReturn;
                @Return.canceled += instance.OnReturn;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnPressAttack(InputAction.CallbackContext context);
        void OnHoldAttack(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnMousePos(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnDebugToggle(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnReturn(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}
