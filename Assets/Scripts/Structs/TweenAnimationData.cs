using System;
using DG.Tweening;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Structs
{
    [Serializable]
    public struct TweenAnimationData
    {
        public readonly float AnimationTime => _animationTime;

        public readonly Ease AnimationEase => _animationEase;

        [SerializeField] private float _animationTime;
        [SerializeField] private Ease _animationEase;
    }
}