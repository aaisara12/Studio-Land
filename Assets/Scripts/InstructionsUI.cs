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
        }
    }
}

