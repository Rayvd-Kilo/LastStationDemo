using GourmetsRealm.LastStationDemo.Controllers;
using GourmetsRealm.LastStationDemo.Data;
using GourmetsRealm.LastStationDemo.Interfaces;
using GourmetsRealm.LastStationDemo.Models;
using GourmetsRealm.LastStationDemo.Objects;
using GourmetsRealm.LastStationDemo.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GourmetsRealm.LastStationDemo.Core
{
    public class GameplayInitializer : IInitializable, IStartable
    {
        private readonly GameplayData _gameplayData;
        private readonly LifetimeScope _parentScope;

        private HandcarModel _handcarModel;
        private HandcarView _handcarView;

        public GameplayInitializer(
            GameplayData gameplayData,
            LifetimeScope parentScope)
        {
            _gameplayData = gameplayData;
            _parentScope = parentScope;
        }
        
        public void Initialize()
        {
            InitializeHandcar();

            //InitializeHeroes();
        }
        
        public void Start()
        {
            _parentScope.CreateChild(builder =>
            {
                builder.RegisterInstance(_handcarModel).AsImplementedInterfaces().AsSelf();

                builder.RegisterInstance(_handcarView).AsImplementedInterfaces().AsSelf();

                builder.RegisterEntryPoint<GameplayLifecycleController>();
            }).name = "Gameplay Scope";
        }

        private void InitializeHandcar()
        {
            var handcarData = _gameplayData.HandcarData;

            var heroCells = new UnitCell<IUnitModel>[handcarData.CellPositions.Length];

            for (var i = 0; i < heroCells.Length; i++)
            {
                heroCells[i] = new UnitCell<IUnitModel>(handcarData.CellPositions[i]);
            }

            _handcarModel = new HandcarModel(handcarData.Health, heroCells);
            
            _handcarView = Object.Instantiate(handcarData.HandcarView,
                new Vector3(handcarData.CarInitialPosition.x, handcarData.CarInitialPosition.y), Quaternion.identity);
        }
    }
}