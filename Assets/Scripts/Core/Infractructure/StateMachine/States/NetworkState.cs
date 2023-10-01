using Core.Data;
using Core.Infractructure.SceneLoader;
using Core.Infractructure.StateMachine.Repository;
using Core.Network.Management;
using Core.Services.SceneComposition;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.StateMachine.States
{
    public class NetworkState : IState
    {
        private readonly INetworkService _networkService;
        private readonly IStateRepository _stateRepository;
        private readonly ISceneComposition _sceneComposition;
        private readonly ISceneLoader _sceneLoader;

        public NetworkState(INetworkService networkService, IStateRepository stateRepository,
            ISceneComposition sceneComposition, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _sceneComposition = sceneComposition;
            _stateRepository = stateRepository;
            _networkService = networkService;
            Init();
        }

        public void Init()
        {
            _stateRepository.AddState(this);
        }

        public async void Enter()
        {
#if UNITY_SERVER
            _networkService.StartServer();
#endif
#if !UNITY_SERVER
            await _sceneLoader.LoadSceneAsync(SceneData.EnviromentSceneName, LoadSceneMode.Additive);

            _networkService.StartClient();
            _sceneComposition.InitSceneSettings();
#endif
        }

        public void Exit()
        {
        }
    }
}