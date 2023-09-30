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
        private ISceneRepository _networkSceneRepository;

        #region Inspector
        [field:SerializeField]public GameObject CameraLookTarget { get; private set; }
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private StarterAssetsInputs _starterAssetsInputs;
        [SerializeField] private BasicRigidBodyPush _basicRigidBodyPush;

        #endregion
        
        [Inject]
        private void Construct(ISceneRepository networkSceneRepository)
        {
            _networkSceneRepository = networkSceneRepository;
        }
        
        public override void OnStartClient()
        {
            _playerInput.enabled = IsOwner;
            if (!IsOwner)
            {
                Destroy(_starterAssetsInputs);
                Destroy(_basicRigidBodyPush);
            }
            else
            {
                _networkSceneRepository.RegisterPlayer(gameObject);
            }
        }
    }
}