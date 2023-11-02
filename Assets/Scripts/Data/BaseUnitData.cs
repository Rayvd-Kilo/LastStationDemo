using GourmetsRealm.LastStationDemo.Interfaces;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Data
{
    public abstract class BaseUnitData<T> : ScriptableObject where T : MonoBehaviour, IUnitView
    {
        [field:SerializeField] public T UnitView { get; private set; }
        
        [field:SerializeField] public int DamagePerHit { get; private set; }
        
        [field:SerializeField] public int HitsCount { get; private set; }
        
        [field:SerializeField] public float TimeBeforeAttack { get; private set; }
        
        [field:SerializeField] public float HitDistance { get; private set; }
    }
}