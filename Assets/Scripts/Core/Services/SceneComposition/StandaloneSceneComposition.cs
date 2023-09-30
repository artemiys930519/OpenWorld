using Cinemachine;
using Core.Game.Units;
using Core.Services.Repository;
using UnityEngine;
using Zenject;

namespace Core.Services.SceneComposition
{
    public class StandaloneSceneComposition : MonoBehaviour,ISceneComposition
    {
        #region Inspector

        [SerializeField] private Camera _camera;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        private ISceneRepository _sceneRepository;

        #endregion

        [Inject]
        private void Construct(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

        private void Start()
        {
            InitSceneSettings();
        }

        public async void InitSceneSettings()
        {
            var connectedPlayer = await _sceneRepository.GetComponentOnPlayer<Player>();
            _cinemachineVirtualCamera.Follow = connectedPlayer.CameraLookTarget.transform;
        }
    }
}