using Core.Infractructure.Factory;
using Infrastructure.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.StateMachine.States
{
    public class InitializeState : IState
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

        public async void Enter()
        {
            await _sceneLoader.LoadSceneAsync("EnviromentScene", LoadSceneMode.Additive);
            await _factory.CreatePlayer(Vector3.zero);
        }
    }
}