using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudioLand
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] InputReaderSO inputReader;

        [Header("Listens on")]
        [SerializeField] VoidEventChannelSO sceneReadyChannelSO;

        void OnEnable()
        {
            sceneReadyChannelSO.OnEventRaised += HandleSceneReady;
        }

        void OnDisable()
        {
            sceneReadyChannelSO.OnEventRaised -= HandleSceneReady;
        }

        void HandleSceneReady()
        {
            // Once everything in the scene is ready, we enter the gameplay state immediately
            // NOTE: Later on we may want a dedicated state tracking variable
            inputReader.EnableGameplayInput();
        }
    }
}

