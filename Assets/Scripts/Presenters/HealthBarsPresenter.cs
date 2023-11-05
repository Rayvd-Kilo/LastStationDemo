using Cysharp.Threading.Tasks.Linq;
using GourmetsRealm.LastStationDemo.Models;
using GourmetsRealm.LastStationDemo.Views;
using VContainer.Unity;

namespace GourmetsRealm.LastStationDemo.Presenters
{
    public class HealthBarsPresenter : IInitializable
    {
        private readonly HealthBarHolderView _healthBarHolderView;
        private readonly HandcarModel _handcarDamageableModel;
        private readonly HordeModel _hordeModel;

        public HealthBarsPresenter(
            HealthBarHolderView healthBarHolderView,
            HandcarModel handcarDamageableModel,
            HordeModel hordeModel)
        {
            _healthBarHolderView = healthBarHolderView;
            _handcarDamageableModel = handcarDamageableModel;
            _hordeModel = hordeModel;
        }
        
        public void Initialize()
        {
            _handcarDamageableModel.Health.Subscribe(UpdateHandCarHealthBar);

            _hordeModel.Health.Subscribe(UpdateEnemiesHordeHealthBar);
        }

        private void UpdateEnemiesHordeHealthBar(int healthValue)
        {
            _healthBarHolderView.EnemiesHealthBar.UpdateHealthValue(healthValue.ToString());
        }

        private void UpdateHandCarHealthBar(int healthValue)
        {
            _healthBarHolderView.HandCarHealthBar.UpdateHealthValue(healthValue.ToString());
        }
    }
}