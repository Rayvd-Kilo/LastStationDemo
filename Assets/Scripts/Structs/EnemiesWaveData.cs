using System;
using GourmetsRealm.LastStationDemo.Data;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Structs
{
    [Serializable]
    public struct EnemiesWaveData
    {
        public readonly EnemyUnitData[] EnemiesUnitData => _enemiesUnitData;
        
        public readonly Vector2 SpawnTimeRange => _spawnTimeRange;

        public readonly int EnemiesCount => _enemiesCount;
        
        [SerializeField] private EnemyUnitData[] _enemiesUnitData;

        [SerializeField] private Vector2 _spawnTimeRange;

        [SerializeField] private int _enemiesCount;
    }
}