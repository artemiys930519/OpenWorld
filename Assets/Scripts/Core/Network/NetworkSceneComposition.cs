using Cinemachine;
using Core.Network.Repository;
using FishNet.Object;
using UnityEngine;
using Zenject;

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
            var connectedPlayer = _networkSceneRepository.GetPlayer();

            if (connectedPlayer.OwnerId == NetworkManager.ClientManager.Connection.ClientId)
            {
                _cinemachineVirtualCamera.Follow = _networkSceneRepository.GetPlayer().CameraLookTarget.transform;
            }
        }
    }
}