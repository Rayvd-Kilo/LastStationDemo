using Cysharp.Threading.Tasks.Linq;
using GourmetsRealm.LastStationDemo.Interfaces;
using GourmetsRealm.LastStationDemo.Views;
using VContainer.Unity;

namespace GourmetsRealm.LastStationDemo.Presenters
{
    public class HealthBarsPresenter : IInitializable
    {
        private readonly HealthBarHolderView _healthBarHolderView;
        private readonly IDamageable _handcarDamageableModel;

        public HealthBarsPresenter(
            HealthBarHolderView healthBarHolderView,
            IDamageable handcarDamageableModel)
        {
            _healthBarHolderView = healthBarHolderView;
            _handcarDamageableModel = handcarDamageableModel;
        }
        
        public void Initialize()
        {
            _handcarDamageableModel.Health.Subscribe(UpdateHandCarHealthBar);
        }

        private void UpdateHandCarHealthBar(int healthValue)
        {
            _healthBarHolderView.HandCarHealthBar.UpdateHealthValue(healthValue.ToString());
        }
    }
}