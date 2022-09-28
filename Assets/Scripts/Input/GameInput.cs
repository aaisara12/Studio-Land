//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Settings/Input/GameInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace StudioLand
{
    public partial class @GameInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""6f648f8d-00d2-4748-bf3d-4d6d0c23a62a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""89c05d99-ab41-4815-9cfc-9507983af2fb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Value"",
                    ""id"": ""57f6d91d-6f27-4375-accc-39df4e21bdcc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3c90a4a3-3883-4b0d-9dd5-83e52a817f85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard WASD"",
                    ""id"": ""475c0055-7629-4838-9c3c-26b5ae8f3d0d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""21df2be7-ad23-4612-99cc-95b242656d65"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b8be3b8f-66a0-42ce-9e87-73112a79dfae"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9c1533dc-552d-445d-ae34-4c15313e1f1a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""aa447ad5-79ab-4275-ae9d-9216aa736345"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fb5cd432-2965-4b3c-ad4f-83fd421906d5"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33b63d0c-91cf-499f-9722-34d09e172c9e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Persistent"",
            ""id"": ""20eeebf0-b149-44f0-8996-819b153998e4"",
            ""actions"": [
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""c75fe599-0120-49c8-a376-614c898763ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3471d391-62db-4755-b440-ecd027110b79"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6edffd3c-c8fc-4715-85c4-2a12d4e1242f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
            m_Gameplay_RotateCamera = m_Gameplay.FindAction("RotateCamera", throwIfNotFound: true);
            m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
            // Persistent
            m_Persistent = asset.FindActionMap("Persistent", throwIfNotFound: true);
            m_Persistent_Quit = m_Persistent.FindAction("Quit", throwIfNotFound: true);
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
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_Gameplay_Move;
        private readonly InputAction m_Gameplay_RotateCamera;
        private readonly InputAction m_Gameplay_Interact;
        public struct GameplayActions
        {
            private @GameInput m_Wrapper;
            public GameplayActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Gameplay_Move;
            public InputAction @RotateCamera => m_Wrapper.m_Gameplay_RotateCamera;
            public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                    @RotateCamera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateCamera;
                    @RotateCamera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateCamera;
                    @RotateCamera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotateCamera;
                    @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @RotateCamera.started += instance.OnRotateCamera;
                    @RotateCamera.performed += instance.OnRotateCamera;
                    @RotateCamera.canceled += instance.OnRotateCamera;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);

        // Persistent
        private readonly InputActionMap m_Persistent;
        private IPersistentActions m_PersistentActionsCallbackInterface;
        private readonly InputAction m_Persistent_Quit;
        public struct PersistentActions
        {
            private @GameInput m_Wrapper;
            public PersistentActions(@GameInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Quit => m_Wrapper.m_Persistent_Quit;
            public InputActionMap Get() { return m_Wrapper.m_Persistent; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PersistentActions set) { return set.Get(); }
            public void SetCallbacks(IPersistentActions instance)
            {
                if (m_Wrapper.m_PersistentActionsCallbackInterface != null)
                {
                    @Quit.started -= m_Wrapper.m_PersistentActionsCallbackInterface.OnQuit;
                    @Quit.performed -= m_Wrapper.m_PersistentActionsCallbackInterface.OnQuit;
                    @Quit.canceled -= m_Wrapper.m_PersistentActionsCallbackInterface.OnQuit;
                }
                m_Wrapper.m_PersistentActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Quit.started += instance.OnQuit;
                    @Quit.performed += instance.OnQuit;
                    @Quit.canceled += instance.OnQuit;
                }
            }
        }
        public PersistentActions @Persistent => new PersistentActions(this);
        public interface IGameplayActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnRotateCamera(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
        }
        public interface IPersistentActions
        {
            void OnQuit(InputAction.CallbackContext context);
        }
    }
}
