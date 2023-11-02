using System;

namespace GourmetsRealm.LastStationDemo.Interfaces
{
    public interface IDamageable
    {
        event Action Destroyed;
        
        int Health { get; }

        void TakeDamage(int damageAmount);
    }
}