using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using GourmetsRealm.LastStationDemo.Data;
using GourmetsRealm.LastStationDemo.Models;
using GourmetsRealm.LastStationDemo.Structs;
using GourmetsRealm.LastStationDemo.Utils;
using GourmetsRealm.LastStationDemo.Views;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace GourmetsRealm.LastStationDemo.Controllers
{
    public class EnemiesSpawningController : IStartable
    {
        private readonly GameplayIterationModel _gameplayIterationModel;
        private readonly ViewModelRepository<EnemyUnitModel, EnemyView> _enemiesRepository;
        private readonly HordeModel _hordeModel;
        private readonly EnemiesGeneratingData _generatingData;

        private readonly PrototypedPool<EnemyUnitModel> _enemiesModelPool;
        private readonly PrototypedPool<EnemyView> _enemiesViewPool;

        private ViewModelRepository<EnemyUnitModel, EnemyView> _prototypeRepository;

        private int _spawnedEnemies;

        public EnemiesSpawningController(
            GameplayIterationModel gameplayIterationModel,
            ViewModelRepository<EnemyUnitModel, EnemyView> enemiesRepository,
            HordeModel hordeModel,
            EnemiesGeneratingData generatingData)
        {
            _gameplayIterationModel = gameplayIterationModel;
            _enemiesRepository = enemiesRepository;
            _hordeModel = hordeModel;
            _generatingData = generatingData;

            InitializeEnemies();

            _enemiesModelPool = new PrototypedPool<EnemyUnitModel>(
                (model => model.Clone()),
                (model) => { model.ResetToDefault(); }, _prototypeRepository.ModelsArray);

            _enemiesViewPool = new PrototypedPool<EnemyView>((view =>
            {
                var prefab = Object.Instantiate(view);

                var model = _enemiesModelPool.GetObject(_prototypeRepository.GetModelByView(view));
                
                _enemiesRepository.AddElement(model, prefab);

                return prefab;
            }), view => view.ResetToDefault(), _prototypeRepository.ViewsArray);
        }

        public void Start()
        {
            SpawnEnemiesAsync(CancellationToken.None).Forget();
        }

        private void InitializeEnemies()
        {
            var enemiesHashSet = new HashSet<EnemyUnitData>();

            foreach (var enemyUnitData in _hordeModel.GetWaveData(_gameplayIterationModel.CurrentInGameIterationTime)
                         .EnemiesUnitData)
            {
                enemiesHashSet.Add(enemyUnitData);
            }

            _prototypeRepository = new ViewModelRepository<EnemyUnitModel, EnemyView>(enemiesHashSet.ToArray());
        }

        private async UniTask SpawnEnemiesAsync(CancellationToken token)
        {
            if (_spawnedEnemies.Equals(_hordeModel.TotalEnemies) || _gameplayIterationModel.IsEndgame) return;

            var waveData = _hordeModel.GetWaveData(_gameplayIterationModel.CurrentInGameIterationTime);

            var views = waveData.EnemiesUnitData.Select(x => x.UnitView).ToArray();

            var generatingCycles = new int[(int)Math.Ceiling((double)(waveData.EnemiesCount / 5))];

            var enemiesCount = waveData.EnemiesCount;

            for (int i = 0; i < generatingCycles.Length; i++)
            {
                if (enemiesCount < 5)
                {
                    generatingCycles[i] = enemiesCount;

                    break;
                }

                generatingCycles[i] = 5;

                enemiesCount -= 5;
            }

            foreach (var generatingCycle in generatingCycles)
            {
                for (int i = 0; i < generatingCycle; i++)
                {
                    var randomPosition = new Vector2(
                        Random.Range(_generatingData.HorizontalBounds.x, _generatingData.HorizontalBounds.y),
                        Random.Range(_generatingData.VerticalBounds.x, _generatingData.VerticalBounds.y));

                    _enemiesViewPool.GetObject(views[Random.Range(0, views.Length)]).transform.position =
                        randomPosition;
                }

                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
        }
    }
}