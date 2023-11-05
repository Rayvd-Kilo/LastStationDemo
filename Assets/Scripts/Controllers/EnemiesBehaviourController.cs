using System;
using Cysharp.Threading.Tasks;
using GourmetsRealm.LastStationDemo.Enums;
using GourmetsRealm.LastStationDemo.Models;
using GourmetsRealm.LastStationDemo.Views;
using UnityEngine;
using VContainer.Unity;

namespace GourmetsRealm.LastStationDemo.Controllers
{
    public class EnemiesBehaviourController : IInitializable
    {
        private readonly ViewModelRepository<EnemyUnitModel, EnemyView> _enemiesRepository;
        private readonly HordeModel _hordeModel;
        private readonly HandcarView _handcarView;
        private readonly HandcarModel _handcarModel;

        public EnemiesBehaviourController(
            ViewModelRepository<EnemyUnitModel, EnemyView> enemiesRepository,
            HordeModel hordeModel,
            HandcarView handcarView,
            HandcarModel handcarModel)
        {
            _enemiesRepository = enemiesRepository;
            _hordeModel = hordeModel;
            _handcarView = handcarView;
            _handcarModel = handcarModel;
        }

        public void Initialize()
        {
            _enemiesRepository.ModelAdded += OnModelAdded;
        }

        private void OnModelAdded(EnemyUnitModel model)
        {
            model.SetCurrentState(UnitState.Moving);

            model.StateUpdated += _ => DoActionAsync(model).Forget();
            
            DoActionAsync(model).Forget();
        }

        private async UniTask DoActionAsync(EnemyUnitModel model)
        {
            var view = _enemiesRepository.GetViewByModel(model);

            await view.DoAnimationAsync(model.CurrentState);

            switch (model.CurrentState)
            {
                case UnitState.Idle:
                    view.DoAnimationAsync(model.CurrentState).Forget();
                    break;
                case UnitState.Attacking:
                    while (_handcarModel.Health.Value > 0)
                    {
                        for (int i = 0; i < model.HitsCount; i++)
                        {
                            _handcarModel.TakeDamage(model.DamagePerHit);
                            
                            view.DoAnimationAsync(UnitState.Idle).Forget();

                            await UniTask.Delay(TimeSpan.FromSeconds(0.5));

                            await view.DoAnimationAsync(model.CurrentState);
                        }

                        await UniTask.Delay(TimeSpan.FromSeconds(model.AttackRechargeTime));
                    }
                    break;
                case UnitState.Moving:
                    var endPoint = _handcarView.transform.position.x + model.HitDistance;

                    await UniTask.WaitUntil(() =>
                    {
                        view.transform.Translate(new Vector3(-1 * model.MoveSpeed, 0) * Time.deltaTime);

                        return view.transform.position.x <= endPoint;
                    });
                    
                    model.SetCurrentState(UnitState.Attacking);
                    
                    break;
                case UnitState.Dying:
                    view.DoAnimationAsync(model.CurrentState).Forget();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}