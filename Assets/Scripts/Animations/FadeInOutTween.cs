using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace StudioLand
{
    public class FadeInOutTween : MonoBehaviour
    {
        [SerializeField] TMPro.TMP_Text text;
        [SerializeField] float cycleTime = 0.5f;
        [SerializeField] bool playOnAwake = false;

        void Awake()
        {
            if(playOnAwake)
                StartAnimation();
        }
        public void StartAnimation()
        {
            text.DOFade(0, cycleTime * 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }
    }
}


