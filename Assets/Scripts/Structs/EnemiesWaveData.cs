using System;
using GourmetsRealm.LastStationDemo.Data;
using UnityEngine;

namespace GourmetsRealm.LastStationDemo.Structs
{
    [Serializable]
    public struct EnemiesWaveData
    {
        public readonly EnemyUnitData[] EnemiesUnitData => _enemiesUnitData;
        
        public readonly float SpawnTime => _spawnTime;

        public readonly int EnemiesCount => _enemiesCount;
        
        [SerializeField] private EnemyUnitData[] _enemiesUnitData;

        [SerializeField] private float _spawnTime;

        [SerializeField] private int _enemiesCount;
    }
}