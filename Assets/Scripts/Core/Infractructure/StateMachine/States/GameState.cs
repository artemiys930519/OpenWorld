using Core.Data;
using Core.Infractructure.SceneLoader;
using Core.Infractructure.StateMachine.Repository;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.StateMachine.States
{
    public class GameState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStateRepository _stateRepository;

        public GameState(ISceneLoader sceneLoader, IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
            _sceneLoader = sceneLoader;
            Init();
        }

        public void Init()
        {
            _stateRepository.AddState(this);
        }

        public async void Enter()
        {
            await _sceneLoader.LoadSceneAsync(SceneData.NetworkSceneName);
            await _sceneLoader.LoadSceneAsync(SceneData.EnviromentSceneName, LoadSceneMode.Additive);
        }

        public void Exit()
        {
        }
    }
}

