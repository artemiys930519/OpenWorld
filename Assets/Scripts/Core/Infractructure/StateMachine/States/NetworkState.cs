using Core.Infractructure.StateMachine.Repository;
using Core.Network.Management;
using Core.Services.SceneComposition;

namespace Core.Infractructure.StateMachine.States
{
    public class NetworkState : IState
    {
        private readonly INetworkService _networkService;
        private readonly IStateRepository _stateRepository;
        private readonly ISceneComposition _sceneComposition;

        public NetworkState(INetworkService networkService, IStateRepository stateRepository, ISceneComposition sceneComposition)
        {
            _sceneComposition = sceneComposition;
            _stateRepository = stateRepository;
            _networkService = networkService;
            Init();
        }

        public void Init()
        {
            _stateRepository.AddState(this);
        }

        public void Enter()
        {
#if UNITY_SERVER
            _networkService.StartServer();
#endif
#if !UNITY_SERVER
            _networkService.StartClient();
            _sceneComposition.InitSceneSettings();
#endif
        }

        public void Exit()
        {
            
        }
    }
}