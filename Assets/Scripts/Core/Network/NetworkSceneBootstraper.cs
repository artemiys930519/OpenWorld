using System;
using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Core.Network
{
    public class NetworkSceneBootstraper : MonoBehaviour
    {
        private StateMachine _stateMachine;

        [Inject]
        private void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _stateMachine.Enter<NetworkState>();
        }
    }
}