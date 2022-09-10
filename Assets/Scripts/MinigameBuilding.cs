using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudioLand
{
    /// <summary>
    /// Class for managing the building displayed based on minigame status
    /// </summary>
    public class MinigameBuilding : MonoBehaviour
    {
        [SerializeField] MinigamePlayer minigamePlayer;
        [Header("Scene References")]
        [SerializeField] GameObject openBuildingRef;
        [SerializeField] GameObject closedBuildingRef;
        [SerializeField] TMPro.TMP_Text titleText;
        [SerializeField] TMPro.TMP_Text scoreText;

        void Awake()
        {
            if(minigamePlayer.isValid)
            {
                openBuildingRef.SetActive(true);
                closedBuildingRef.SetActive(false);
            }
            else
            {
                // Minigame is not in a finished state and so building should be closed
                openBuildingRef.SetActive(false);
                closedBuildingRef.SetActive(true);
            }
        }

    }
}

