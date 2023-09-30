using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using Infrastructure.SceneLoader;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class GameBootstrapper : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private Transform _playerSpawnPoint;

        #endregion
        private StateMachine _stateMachine;
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader,StateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        private void Start()
        {
            _stateMachine.Enter<InitializeState,Vector3>(_playerSpawnPoint.position);
        }

        public void LoadGameScene()
        {
            _stateMachine.Enter<GameState>();
        }
    }
}