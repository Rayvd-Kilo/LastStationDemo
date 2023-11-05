using Cysharp.Threading.Tasks;
using GourmetsRealm.LastStationDemo.Enums;
using GourmetsRealm.LastStationDemo.Interfaces;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Views
{
    public class EnemyView : MonoBehaviour, IUnitView
    {
        public void ResetToDefault()
        {
            DoAnimationAsync(UnitState.Idle).Forget();
        }

        public async UniTask DoAnimationAsync(UnitState unitState)
        {
            
        }
    }
}