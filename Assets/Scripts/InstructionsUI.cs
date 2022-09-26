using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace StudioLand
{
    public class InstructionsUI : MonoBehaviour
    {
        [SerializeField] UIDocument document;
        [SerializeField] UnityEvent entranceAnimation;
        [SerializeField] InputReaderSO playerInput;

        

        [Header("Broadcasts on")]
        [SerializeField] MinigameEventChannelSO minigameEventChannel;
        [SerializeField] VoidEventChannelSO panelClosedEventChannel;

        [Header("Listens on")]
        [SerializeField] LoadEventChannelSO requestLoadSceneChannel;
        [SerializeField] VoidEventChannelSO sceneReadyEventChannel;
        
        VisualElement root;

        void Awake()
        {
            root = document.rootVisualElement;
        }

        void OnEnable()
        {
            minigameEventChannel.OnEventRaised += HandleNewMinigame;
            sceneReadyEventChannel.OnEventRaised += HandleSceneReady;
        }

        void OnDisable()
        {
            minigameEventChannel.OnEventRaised -= HandleNewMinigame;
            sceneReadyEventChannel.OnEventRaised -= HandleSceneReady;
        }

        void HandleNewMinigame(MinigameSO minigame)
        {
            playerInput.EnableUIInput();
            
            root.Q<Label>("Title").text = minigame.title;
            entranceAnimation?.Invoke();

            root.Q<Label>("Description").text = minigame.instructions;

            StyleBackground pic = new StyleBackground();
            pic.value = Background.FromSprite(minigame.picture);

            root.Q("Picture").style.backgroundImage = pic;

            root.Q<Button>("Play").RegisterCallback<ClickEvent>(ev => PlayMinigame(minigame));
        }
        
        void HandleSceneReady()
        {
            // The reason we're putting it when the next scene readies and not when the current one is unloaded is simply
            // to save us from having to create an additional channel -- it shouldn't make an impact in this game

            root.style.opacity = 0; // Hide the UI
        }

        void PlayMinigame(MinigameSO minigame)
        {
            requestLoadSceneChannel.RaiseEvent(minigame.scene);
        }

        
    }
}

