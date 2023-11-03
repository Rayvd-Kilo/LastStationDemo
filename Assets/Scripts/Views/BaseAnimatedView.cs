using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GourmetsRealm.LastStationDemo.Structs;
using GourmetsRealm.LastStationDemo.Utils;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Views
{
    public abstract class BaseAnimatedView : MonoBehaviour
    {
        [SerializeField] protected TweenAnimationData _appearAnimationData;
        
        [SerializeField] protected TweenAnimationData _disappearAnimationData;
        
        private Tween _activeTween;

        private CancellationTokenSource _cancellationTokenSource;
        
        protected async UniTask DoAppearAnimationAsync(Func<Tween> tweenFunc, CancellationToken token)
        {
            await DoAnimationAsync(tweenFunc, _appearAnimationData, token);
        }

        protected async UniTask DoDisappearAnimationAsync(Func<Tween> tweenFunc, CancellationToken token)
        {
            await DoAnimationAsync(tweenFunc, _disappearAnimationData, token);
        }
        
        private async UniTask DoAnimationAsync(Func<Tween> tweenFunc, TweenAnimationData tweenAnimationData, CancellationToken token)
        {
            _cancellationTokenSource.CancelToken();
            
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
            
            _activeTween.KillActiveTween();

            _activeTween = tweenFunc.Invoke().SetEase(tweenAnimationData.AnimationEase);

            await _activeTween.AsyncWaitForCompletion();
        }
    }
}