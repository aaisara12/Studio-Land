using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace StudioLand
{
    /// <summary>
    /// Class for anything that can be interacted with in the game. Displays requested interaction input to user based on
    /// a trigger and invokes a UnityEvent when it detects that press (just like a button but you need to be in the
    /// range of the interactable)
    /// </summary>
    public class Interactable : MonoBehaviour
    {
        [SerializeField] UnityEvent OnInteract = new UnityEvent();
        [SerializeField] GameObject interactIndicator;
        [SerializeField] InteractablesRuntimeSetSO interactablesRuntimeSet;

        bool isWithinRange = false;

        /// <summary> Toggle the visual indicator for this interactable </summary>
        public void SetHighlight(bool shouldHighlight)
        {
            interactIndicator.SetActive(shouldHighlight);
        }

        /// <summary> Trigger the interaction </summary>
        public void ExecuteInteraction()
        {
            OnInteract?.Invoke();
        }

        void OnEnable()
        {
            // Default state is off and can be switched on if player detected
            interactIndicator.SetActive(false);
        }

        void OnDisable()
        {
            // In case it the gameobject is deactivated without the player leaving the trigger zone
            interactablesRuntimeSet.runtimeSet.Remove(this);
        }


        void OnTriggerEnter(Collider collider)
        {
            // This is a relatively simple project so tag checking should be fine as opposed to a more robust method
            if(collider.CompareTag("Player"))
            {
                interactablesRuntimeSet.runtimeSet.Add(this);
            }
                
        }

        void OnTriggerExit(Collider collider)
        {
            if(collider.CompareTag("Player"))
            {
                interactablesRuntimeSet.runtimeSet.Remove(this);
            }      
        }
    }
}

