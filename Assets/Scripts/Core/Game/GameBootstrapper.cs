using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using Infrastructure.SceneLoader;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class GameBootstrapper : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader,StateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        private void Start()
        {
            _stateMachine.Enter<InitializeState>();
        }

        public async void LoadGameScene()
        {
            await _sceneLoader.LoadSceneAsync("NetworkInfrastructureScene");
        }
    }
}