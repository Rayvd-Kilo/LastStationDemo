using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GourmetsRealm.LastStationDemo.Interfaces;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Views
{
    public class HandcarView : BaseAnimatedView, IResettable
    {
        public Transform CellsParent => _cellsParent;
        
        [SerializeField] private Transform _cellsParent;

        private Tween _activeTween;

        private Vector2 _initialPosition;

        private CancellationTokenSource _cancellationTokenSource;

        private void Start()
        {
            _initialPosition = transform.position;
        }

        public async UniTask DoStartAnimationAsync(float horizontalEndPoint, CancellationToken token)
        {
            await DoAppearAnimationAsync(
                () => transform.DOMoveX(horizontalEndPoint, _appearAnimationData.AnimationTime), token);
        }

        public async UniTask DoEndAnimationAsync(float horizontalEndPoint, CancellationToken token)
        {
            await DoDisappearAnimationAsync(
                () => transform.DOMoveX(horizontalEndPoint, _disappearAnimationData.AnimationTime), token);
        }
        
        public void ResetToDefault()
        {
            transform.position = _initialPosition;
        }
    }
}