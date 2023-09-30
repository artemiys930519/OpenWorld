using Infrastructure.SceneLoader;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.StateMachine.States
{
    public class GameState : IState
    {
        private readonly ISceneLoader _sceneLoader;

        public GameState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Exit()
        {
        }

        public async void Enter()
        {
            await _sceneLoader.LoadSceneAsync("NetworkInfrastructureScene");
            await _sceneLoader.LoadSceneAsync("EnviromentScene", LoadSceneMode.Additive);
        }
    }
}

