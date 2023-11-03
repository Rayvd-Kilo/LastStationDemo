using GourmetsRealm.LastStationDemo.Core;
using GourmetsRealm.LastStationDemo.Data;
using GourmetsRealm.LastStationDemo.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GourmetsRealm.LastStationDemo.EntryPoint
{
    public class LastStationCompositeRoot : LifetimeScope
    {
        [SerializeField] private GameplayData _gameplayData;

        [SerializeField] private HealthBarHolderView _healthBarHolderView;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterInstance(_gameplayData);

            builder.RegisterComponent(_healthBarHolderView);

            builder.RegisterEntryPoint<GameplayInitializer>();
        }
    }
}