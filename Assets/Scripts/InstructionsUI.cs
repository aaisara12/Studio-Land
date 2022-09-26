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

            //root.Q<VisualElement>("MainPanel").Focus();
            
            entranceAnimation?.Invoke();
            
            root.Q<Label>("Title").text = minigame.title;
            

            root.Q<Label>("Description").text = minigame.instructions;

            StyleBackground pic = new StyleBackground();
            pic.value = Background.FromSprite(minigame.picture);

            root.Q("Picture").style.backgroundImage = pic;

            root.Q<Button>("Play").RegisterCallback<ClickEvent>(ev => PlayMinigame(minigame));

            
        }

        void CleanUpPanel()
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
            root.Q<VisualElement>("MainPanel").Focus();
            root.Q<VisualElement>("ExitBackground").RegisterCallback<FocusEvent>(ev => CleanUpPanel());
            root.style.opacity = 0;
            root.style.display = DisplayStyle.None;
        }

        
    }
}

