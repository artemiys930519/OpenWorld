using System;
using Core.Events;
using Core.Infractructure.SceneLoader;
using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class GameBootstrapper : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private Transform _playerSpawnPoint;

        #endregion

        private StateMachine _stateMachine;
        private ISceneLoader _sceneLoader;
        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus, ISceneLoader sceneLoader, StateMachine stateMachine)
        {
            _signalBus = signalBus;
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<RaisePortalSignal>(LoadGameScene);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<RaisePortalSignal>(LoadGameScene);
        }

        private void Start()
        {
            _stateMachine.Enter<InitializeState, Transform>(_playerSpawnPoint);
        }

        public void LoadGameScene(RaisePortalSignal raisePortalSignal)
        {
            _stateMachine.Enter<GameState>();
        }
    }
}