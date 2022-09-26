using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StudioLand
{
    [CreateAssetMenu( fileName = "InputReader", menuName = "ScriptableObjects/Input Reader")]
    public class InputReaderSO : DescriptionBaseSO, GameInput.IGameplayActions
    {
        GameInput gameInput = default;
        [SerializeField] InputActionReference cinemachineActionRef;  // Input action asset assigned for cinemachine's input reader
        // Callbacks
        public event System.Action<Vector2> MoveEvent = delegate {};
        public event System.Action<Vector2> RotateCameraEvent = delegate {};
        public event System.Action InteractEvent = delegate {};


        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnRotateCamera(InputAction.CallbackContext context)
        {
            RotateCameraEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if(context.performed)
                InteractEvent?.Invoke();
        }




        // NOTE: OnEnable for a ScriptableObject is called either when it is first created or the project is recompiled
        void OnEnable()
        {
            // NOTE: This whole ScriptableObject is simply a wrapper around a single GameInput instance
            if(gameInput == null)
            {
                // Because the project always recompiles when the input mapping changes, this SO will always be up to date
                gameInput = new GameInput();
                gameInput.Gameplay.SetCallbacks(this);
            }
        }

        public void EnableGameplayInput()
        {
            gameInput.Gameplay.Enable();
            cinemachineActionRef.action.Enable();
        }

        public void EnableUIInput()
        {
            gameInput.Gameplay.Disable();
            cinemachineActionRef.action.Disable();
        }

        public void DisableAllInput()
        {
            gameInput.Gameplay.Disable();
            cinemachineActionRef.action.Disable();
        }
    }
}

