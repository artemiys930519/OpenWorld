using Core.Network.Repository;
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
        [field:SerializeField]public PlayerInput PlayerInput { get; private set; }
        [field:SerializeField]public ThirdPersonController ThirdPersonController { get; private set; }
        [field:SerializeField]public StarterAssetsInputs StarterAssetsInputs { get; private set; }
        [field:SerializeField]public BasicRigidBodyPush BasicRigidBodyPush { get; private set; }
        [field:SerializeField]public CharacterController CharacterController { get; private set; }
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
            if (IsOwner)
            {
                PlayerInput.enabled = true;
                PlayerInput.ActivateInput();
            }
            else
            {
                Destroy(ThirdPersonController);
                Destroy(CharacterController);
                Destroy(PlayerInput);
                Destroy(StarterAssetsInputs);
                Destroy(BasicRigidBodyPush);
            }
        }
    }
}