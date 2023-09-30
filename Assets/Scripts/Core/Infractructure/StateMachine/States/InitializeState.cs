using Core.Infractructure.Factory;
using Infrastructure.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.StateMachine.States
{
    public class InitializeState : IPayloadedState<Vector3>
    {
        private IFactory _factory;
        private StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public InitializeState(IFactory factory, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;

            _factory = factory;
        }
        public void Exit()
        {
        }

        public async void Enter(Vector3 payload)
        {
            await _sceneLoader.LoadSceneAsync("EnviromentScene", LoadSceneMode.Additive);
            await _factory.CreatePlayer(payload);
        }
    }
}