using Core.Services.Repository;
using FishNet.Object;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.Network.Units
{
    public class NetworkPlayer: NetworkBehaviour
    {
        #region Inspector
        [field:SerializeField]public GameObject CameraLookTarget { get; private set; }
        [field:SerializeField]public PlayerInput PlayerInput{ get; private set; }
        [field:SerializeField]public StarterAssetsInputs StarterAssetsInputs{ get; private set; }
        [field:SerializeField]public BasicRigidBodyPush BasicRigidBodyPush{ get; private set; }
        #endregion
        
        private ISceneRepository _networkSceneRepository;

        [Inject]
        private void Construct(ISceneRepository networkSceneRepository)
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
                _networkSceneRepository.RegisterPlayer(gameObject);
            }
        }
    }
}