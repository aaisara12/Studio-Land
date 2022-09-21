using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class FadeManager : MonoBehaviour
{
    [SerializeField] Image blackScreen;
    [SerializeField] FloatEventChannelSO fadeInRequestChannel;
    [SerializeField] FloatEventChannelSO fadeOutRequestChannel;

    void OnEnable()
    {
        fadeInRequestChannel.OnEventRaised += HandleFadeInRequested;
        fadeOutRequestChannel.OnEventRaised += HandleFadeOutRequested;
    }

    void OnDisable()
    {
        fadeInRequestChannel.OnEventRaised -= HandleFadeInRequested;
        fadeOutRequestChannel.OnEventRaised -= HandleFadeOutRequested;
    }

    void HandleFadeInRequested(float duration)
    {
        blackScreen.DOFade(0, duration);
    }

    void HandleFadeOutRequested(float duration)
    {
        blackScreen.DOFade(1, duration);
    }
}
