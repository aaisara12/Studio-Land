using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace StudioLand
{
    /// <summary>
    /// Simple component for notifying the game that a player wants to play a minigame
    /// </summary>
    public class MinigamePlayer : MonoBehaviour
    {
        [SerializeField] MinigameSO minigame;
        [SerializeField] MinigameEventChannelSO minigameEventChannelSO;
        [SerializeField] UnityEvent<MinigameSO> OnValidate = new UnityEvent<MinigameSO>();
        bool isValid
        {
            get => minigame != null && minigame.scene.editorAsset != null;
        }

        void Start()
        {
            if(isValid)
                OnValidate?.Invoke(minigame);
        }

        public void PlayMinigame()
        {
            if(isValid)
                minigameEventChannelSO.RaiseEvent(minigame);

            // TODO: Send an error status to some error module to display on the UI if not valid

        }

    }
}

