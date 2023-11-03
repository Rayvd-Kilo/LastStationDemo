using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Views
{
    public class HealthBarHolderView : BaseAnimatedView
    {
        public HealthBarView HandCarHealthBar => _handCarHealthBar;
        
        public HealthBarView EnemiesHealthBar => _handCarHealthBar;
        
        [SerializeField] private HealthBarView _handCarHealthBar;
        
        [SerializeField] private HealthBarView _enemiesHealthBar;

        [SerializeField] private float _outOfScreenPoint;

        [SerializeField] private float _onscreenEndPoint;

        private Tween _activeTween;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public async UniTask DoStartAnimationAsync(CancellationToken token)
        {
            await DoAppearAnimationAsync(
                () => _rectTransform.DOAnchorPosY(_onscreenEndPoint, _appearAnimationData.AnimationTime), token);
        }

        public async UniTask DoEndAnimationAsync(CancellationToken token)
        {
            await DoAppearAnimationAsync(
                () => _rectTransform.DOAnchorPosY(_outOfScreenPoint, _appearAnimationData.AnimationTime), token);
        }
    }
}