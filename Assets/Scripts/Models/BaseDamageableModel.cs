using System;
using Cysharp.Threading.Tasks;
using GourmetsRealm.LastStationDemo.Interfaces;

namespace GourmetsRealm.LastStationDemo.Models
{
    public abstract class BaseDamageableModel : IDamageable
    {
        public event Action Destroyed;
        
        public IAsyncReactiveProperty<int> Health { get; protected set; }
        
        public void TakeDamage(int damageAmount)
        {
            Health.Value -= damageAmount;

            if (Health.Value <= 0)
            {
                Destroyed?.Invoke();
            }
        }
    }
}