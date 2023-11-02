using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GourmetsRealm.LastStationDemo.Structs;
using GourmetsRealm.LastStationDemo.Utils;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Views
{
    public class HandcarView : MonoBehaviour
    {
        [SerializeField] private Transform _cellsParent;
        
        [Header("Animation Data")]

        [SerializeField] private TweenAnimationData _startAnimationData;

        [SerializeField] private TweenAnimationData _endgameAnimationData;

        private Tween _activeTween;
        
        public async UniTask DoStartAnimationAsync(float horizontalEndPoint, CancellationToken token)
        {
            await DoAnimationAsync(horizontalEndPoint, _startAnimationData).WithCancellation(token);
        }

        public async UniTask DoEndAnimationAsync(float horizontalEndPoint, CancellationToken token)
        {
            await DoAnimationAsync(horizontalEndPoint, _endgameAnimationData).WithCancellation(token);
        }

        private async UniTask DoAnimationAsync(float horizontalEndPoint, TweenAnimationData tweenAnimationData)
        {
            _activeTween.KillActiveTween();

            _activeTween = transform.DOMoveX(horizontalEndPoint, tweenAnimationData.AnimationTime)
                .SetEase(tweenAnimationData.AnimationEase);

            await _activeTween.AsyncWaitForCompletion();
        }
    }
}