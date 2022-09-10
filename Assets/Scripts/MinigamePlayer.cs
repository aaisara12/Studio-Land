using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudioLand
{
    /// <summary>
    /// Simple component for 
    public class MinigamePlayer : MonoBehaviour
    {
        [SerializeField] MinigameSO minigame;
        [SerializeField] MinigameEventChannelSO minigameEventChannelSO;
        public bool isValid
        {
            get => minigame != null && minigame.scene != null;
        }

        public void PlayMinigame()
        {
            if(isValid)
                minigameEventChannelSO.RaiseEvent(minigame);

            // TODO: Send an error status to some error module to display on the UI if not valid

        }

    }
}

