using Core.Game.Units;
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

        [field: SerializeField] public Player Player { get; private set; }

        #endregion
        
        [Inject]
        private void Construct(ISceneRepository networkSceneRepository)
        {
            _networkSceneRepository = networkSceneRepository;
        }
        
        public override void OnStartClient()
        {
            Player.PlayerInput.enabled = IsOwner;
            if (!IsOwner)
            {
                Destroy(Player.StarterAssetsInputs);
                Destroy(Player.BasicRigidBodyPush);
            }
            else
            {
                _networkSceneRepository.RegisterPlayer(gameObject);
            }
        }
    }
}