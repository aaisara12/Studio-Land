using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

namespace StudioLand
{
    public class SceneInitializer : MonoBehaviour
    {
        [SerializeField] AssetReference persistentManagersScene = default;
        [SerializeField] VoidEventChannelSO OnSceneReadyEventChannelSO = default;
        bool isColdStart = false;

        void Awake()
        {
            // We consider it a "cold start" if the game doesn't have it's managers up and running when this scene
            // loads, which happens if we directly play this scene instead of getting to this scene from a different one.
            if(!SceneManager.GetSceneByName(persistentManagersScene.editorAsset.name).isLoaded)
            {
                persistentManagersScene.LoadSceneAsync(LoadSceneMode.Additive, true);
                isColdStart = true;
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            // We want to raise the event after all the listeners in the scene have had the chance to subscribe 
            if(isColdStart)
            {
                OnSceneReadyEventChannelSO.RaiseEvent();
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

