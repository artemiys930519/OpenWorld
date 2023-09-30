using System;
using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using Core.Logic;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class Portal : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private GameBootstrapper _gameBootstrapper;
        [SerializeField] private TriggerObserver _triggerObserver;
        private StateMachine _stateMachine;

        #endregion
        
        [Inject]
        private void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += OnPlayerTriggerEnter;
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerEnter -= OnPlayerTriggerEnter;
        }

        private void OnPlayerTriggerEnter()
        {
            _gameBootstrapper.LoadGameScene();
        }
    }
}