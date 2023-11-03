using System;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Structs
{
    [Serializable]
    public struct StageData
    {
        public readonly EnemiesWaveData[] EnemiesOnStageData => _enemiesOnStageData;
        
        [SerializeField] private EnemiesWaveData[] _enemiesOnStageData;
    }
}