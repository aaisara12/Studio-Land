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
        [SerializeField] TMPro.TMP_Text inputHint = default;
        
    }
}

