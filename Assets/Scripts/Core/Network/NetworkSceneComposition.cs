using System.Collections;
using Cinemachine;
using Core.Network.Repository;
using FishNet;
using FishNet.Object;
using FishNet.Transporting;
using UnityEngine;
using Zenject;
using NetworkPlayer = Core.Network.Units.NetworkPlayer;

namespace Core.Network
{
    public class NetworkSceneComposition : NetworkBehaviour
    {
        #region Inspector

        [SerializeField] private Camera _camera;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        #endregion

        private INetworkSceneRepository _networkSceneRepository;

        [Inject]
        private void Construct(INetworkSceneRepository networkSceneRepository)
        {
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

            PlayerInit();
        }

        private async void PlayerInit()
        {
            var connectedPlayer = await _networkSceneRepository.GetLocalPlayer();
            _cinemachineVirtualCamera.Follow = connectedPlayer.CameraLookTarget.transform;
        }

    }
}