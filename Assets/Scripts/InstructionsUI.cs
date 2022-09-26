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
        [SerializeField] UnityEvent closingAnimation;
        [SerializeField] InputReaderSO playerInput;
        [SerializeField] float spamThresholdTime = 0.5f;        // How long must the user wait before opening/closing after recently doing so?
        

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
            Initialize();
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
            
            entranceAnimation?.Invoke();
            
            root.Q<Label>("Title").text = minigame.title;
            

            root.Q<Label>("Description").text = minigame.instructions;

            StyleBackground pic = new StyleBackground();
            pic.value = Background.FromSprite(minigame.picture);

            root.Q("Picture").style.backgroundImage = pic;

            root.Q<Button>("Play").RegisterCallback<ClickEvent>(ev => PlayMinigame(minigame));

            
        }

        public void CleanUpPanel()
        {
            closingAnimation?.Invoke();
            playerInput.EnableGameplayInput();
            panelClosedEventChannel.RaiseEvent();
        }
        
        void HandleSceneReady()
        {
            // The reason we're putting it when the next scene readies and not when the current one is unloaded is simply
            // to save us from having to create an additional channel -- it shouldn't make an impact in this game

            Initialize();
        }

        void PlayMinigame(MinigameSO minigame)
        {
            requestLoadSceneChannel.RaiseEvent(minigame.scene);
        }

        void Initialize()
        {
            root.style.opacity = 0;
            root.style.display = DisplayStyle.None;
        }

        
    }
}

