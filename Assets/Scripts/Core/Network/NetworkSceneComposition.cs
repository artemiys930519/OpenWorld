using Cinemachine;
using Core.Network.Management;
using Core.Services.Repository;
using FishNet.Object;
using UnityEngine;
using Zenject;
using NetworkPlayer = Core.Network.Units.NetworkPlayer;

namespace Core.Network
{
    public class NetworkSceneComposition : NetworkBehaviour, ISceneComposition
    {
        #region Inspector

        [SerializeField] private Camera _camera;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        #endregion

        private ISceneRepository _networkSceneRepository;
        private INetworkService _networkService;

        [Inject]
        private void Construct(INetworkService networkService, ISceneRepository networkSceneRepository)
        {
            _networkService = networkService;
            _networkSceneRepository = networkSceneRepository;
        }

        public override void OnStartServer()
        {
            Destroy(_camera.gameObject);
            Destroy(_cinemachineVirtualCamera.gameObject);
        }

        public override void OnStartClient()
        {
            if (IsServer)
                return;

            InitSceneSettings();
        }

        private async void PlayerInit()
        {
            var connectedPlayer = await _networkSceneRepository.GetComponentOnPlayer<NetworkPlayer>();
            _cinemachineVirtualCamera.Follow = connectedPlayer.CameraLookTarget.transform;
        }

        public void InitSceneSettings()
        {
            PlayerInit();
        }
    }
}