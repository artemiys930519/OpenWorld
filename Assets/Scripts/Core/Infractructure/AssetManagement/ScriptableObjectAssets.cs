using Cysharp.Threading.Tasks;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Infrastructure.AssetManagement
{
    public class ScriptableObjectAssets : IAssets
    {
        private readonly PrefabSettings _prefabSettings;
        private readonly DiContainer _diContainer;

        public ScriptableObjectAssets(DiContainer diContainer, PrefabSettings prefabSettings)
        {
            _diContainer = diContainer;
            _prefabSettings = prefabSettings;
        }

        public async UniTask<GameObject> InstantiatePlayer(Vector3 at)
        {
            var untc = new UniTaskCompletionSource<GameObject>();
            
            untc.TrySetResult(_diContainer.InstantiatePrefab(_prefabSettings.PlayerPrefab));
            
            return await untc.Task;
        }
    }
}