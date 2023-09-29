using Core.Game.Units;
using Core.Network.Repository;
using FishNet.Object;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.Network.Units
{
    public class NetworkPlayer: NetworkBehaviour, IUnits
    {
        private INetworkSceneRepository _networkSceneRepository;

        #region Inspector
        [field:SerializeField]public GameObject CameraLookTarget { get; private set; }
        [field:SerializeField]public PlayerInput PlayerInput{ get; private set; }
        [field:SerializeField]public StarterAssetsInputs StarterAssetsInputs{ get; private set; }
        [field:SerializeField]public BasicRigidBodyPush BasicRigidBodyPush{ get; private set; }

        #endregion
        
        [Inject]
        private void Construct(INetworkSceneRepository networkSceneRepository)
        {
            _networkSceneRepository = networkSceneRepository;
        }
        
        public override void OnStartClient()
        {
            PlayerInput.enabled = IsOwner;
            if (!IsOwner)
            {
                Destroy(StarterAssetsInputs);
                Destroy(BasicRigidBodyPush);
            }
            else
            {
                _networkSceneRepository.RegisterPlayer(this);
            }
        }
    }
}