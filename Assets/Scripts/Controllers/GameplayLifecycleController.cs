using System.Threading;
using Cysharp.Threading.Tasks;
using GourmetsRealm.LastStationDemo.Presenters;
using GourmetsRealm.LastStationDemo.Views;
using VContainer.Unity;

namespace GourmetsRealm.LastStationDemo.Controllers
{
    public class GameplayLifecycleController : IAsyncStartable
    {
        private readonly HandcarView _handcarView;
        private readonly LifetimeScope _parentScope;
        private readonly HealthBarHolderView _healthBarHolderView;

        public GameplayLifecycleController(
            HandcarView handcarView,
            LifetimeScope parentScope,
            HealthBarHolderView healthBarHolderView)
        {
            _handcarView = handcarView;
            _parentScope = parentScope;
            _healthBarHolderView = healthBarHolderView;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await StartGameplayAsync(cancellation);
        }

        private async UniTask StartGameplayAsync(CancellationToken token)
        {
            await _handcarView.DoStartAnimationAsync(-6.5f, token);

            var iterationScope = _parentScope.CreateChild(builder =>
            {
                builder.RegisterEntryPoint<HeroesBehaviourController>();
                
                builder.RegisterEntryPoint<EnemiesSpawningController>();

                builder.RegisterEntryPoint<EnemiesBehaviourController>();
                
                builder.RegisterEntryPoint<HealthBarsPresenter>();
            });
            
            await _healthBarHolderView.DoStartAnimationAsync(token);
            
            iterationScope.Dispose();
            
            _healthBarHolderView.DoEndAnimationAsync(token).Forget();

            await _handcarView.DoEndAnimationAsync(30, token);
        }
    }
}