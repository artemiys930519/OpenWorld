using Core.Network.Repository;
using FishNet.Object;
using UnityEngine;
using Zenject;

namespace Core.Network.Units
{
    public class NetworkPlayer: NetworkBehaviour
    {
        #region Inspector
        [field:SerializeField]public GameObject CameraLookTarget { get; private set; }
        #endregion

        private INetworkSceneRepository _networkSceneRepository;

        [Inject]
        private void Construct(INetworkSceneRepository networkSceneRepository)
        {
            _networkSceneRepository = networkSceneRepository;
            _networkSceneRepository.RegisterPlayer(this);
        }

        public override void OnStartClient()
        {
            
        }

        private void Update()
        {
            if (!IsOwner)
                return;
            
        }
    }
}