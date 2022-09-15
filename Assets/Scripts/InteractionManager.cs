using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudioLand
{
    /// <summary>
    /// Script for ensuring interactions are processed one at a time 
    /// </summary>
    public class InteractionManager : MonoBehaviour
    {
        [SerializeField] InputReaderSO inputReader;
        [SerializeField] InteractablesRuntimeSetSO interactablesRuntimeSet;
        [SerializeField] TransformAnchor interactorTransformAnchor;     // This will be the player, usually
        Interactable currentInteractable;

        [Header("Broadcasts on")]
        [SerializeField] VoidEventChannelSO interactionReadyChannelSO;
        [SerializeField] VoidEventChannelSO interactionUnreadyChannelSO;




        bool detectedPotentialInteractableLastUpdate = false;

        // Update is called once per frame
        void Update()
        {
            SetCurrentInteractable();
        }

        void SetCurrentInteractable()
        {
            if(interactablesRuntimeSet.runtimeSet.Count == 0)
                currentInteractable = null;
            else
                currentInteractable = interactablesRuntimeSet.runtimeSet[0];
            
            // Locate the closest interactable within range that is not behind the player
            Interactable nextCurrentInteractable = null;
            if(interactorTransformAnchor.Value != null)
                nextCurrentInteractable = FindNextCurrentInteractable(interactorTransformAnchor.Value, interactablesRuntimeSet.runtimeSet);
            

            // Clean up old highlight and draw new highlight
            currentInteractable?.SetHighlight(false);           // It's possible that the current interactable was destroyed last frame and thus would be missing ref
            nextCurrentInteractable?.SetHighlight(true);
            currentInteractable = nextCurrentInteractable;

            // If a change has been detected since last frame, raise the proper event
            bool detectedPotentialInteractableThisUpdate = (nextCurrentInteractable != null);
            if(detectedPotentialInteractableLastUpdate && !detectedPotentialInteractableThisUpdate)
            {
                interactionUnreadyChannelSO.RaiseEvent();
            }
            else if(!detectedPotentialInteractableLastUpdate && detectedPotentialInteractableThisUpdate)
            {
                interactionReadyChannelSO.RaiseEvent();
            }
            detectedPotentialInteractableLastUpdate = detectedPotentialInteractableThisUpdate;
        }

        Interactable FindNextCurrentInteractable(Transform interactorTransform, IEnumerable<Interactable> interactables)
        {
            Interactable nextCurrentInteractable = null;
            float smallestInteractableScore = float.MaxValue;
            
            foreach(Interactable interactable in interactables)
            {
                // Default turn off all interactables
                interactable.SetHighlight(false);

                Vector3 interactableVector = interactable.transform.position - interactorTransform.position;
                float interactableScore = Vector3.Dot(interactableVector, interactorTransform.forward);

                // We don't want to consider interactables that the player is not facing
                if(interactableScore < 0)
                    interactableScore = float.MaxValue;
                
                if(interactableScore < smallestInteractableScore)
                {
                    smallestInteractableScore = interactableScore;
                    nextCurrentInteractable = interactable;
                }
            }

            return nextCurrentInteractable;
        }

    }
}

