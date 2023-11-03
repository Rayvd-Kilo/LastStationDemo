using System;
using Cysharp.Threading.Tasks;

namespace GourmetsRealm.LastStationDemo.Interfaces
{
    public interface IDamageable
    {
        event Action Destroyed;
        
        IAsyncReactiveProperty<int> Health { get; }

        void TakeDamage(int damageAmount);
    }
}