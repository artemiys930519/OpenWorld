using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.Repository
{
    public class SceneRepository : ISceneRepository
    {
        private GameObject _player;

        public void RegisterPlayer(GameObject player)
        {
            _player = player;
        }

        public async UniTask<GameObject> GetPlayer()
        {
            await UniTask.WaitUntil(() => _player != null);
            return _player;
        }

        public async UniTask<T> GetComponentOnPlayer<T>()
        {
            await UniTask.WaitUntil(() => _player != null);
            var untc = new UniTaskCompletionSource<T>();

            if (_player.TryGetComponent(out T component))
            {
                untc.TrySetResult(component);
            }

            return await untc.Task;
        }
    }
}