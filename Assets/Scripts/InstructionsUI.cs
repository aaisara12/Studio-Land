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
        [SerializeField] MinigameEventChannelSO minigameEventChannel;
        [SerializeField] UnityEvent entranceAnimation;
        
        VisualElement root;

        void Awake()
        {
            root = document.rootVisualElement;
        }

        void OnEnable()
        {
            minigameEventChannel.OnEventRaised += HandleNewMinigame;
        }

        void OnDisable()
        {
            minigameEventChannel.OnEventRaised -= HandleNewMinigame;
        }

        void HandleNewMinigame(MinigameSO minigame)
        {
            root.Q<Label>("Title").text = minigame.title;
            entranceAnimation?.Invoke();

            root.Q<Label>("Description").text = minigame.instructions;

            StyleBackground pic = new StyleBackground();
            pic.value = Background.FromSprite(minigame.picture);

            root.Q("Picture").style.backgroundImage = pic;

            root.Q<Button>("Play").RegisterCallback<ClickEvent>(ev => PlayMinigame(minigame));
        }

        private void PlayMinigame(MinigameSO minigame)
        {
            // Replace this with some kind of exposed UnityEvent callback that talks to the scene loader module and other systems
            minigame.scene.LoadSceneAsync();
        }
    }
}

