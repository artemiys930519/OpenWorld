using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagement;
using UnityEngine;

namespace Core.Infractructure.Factory
{
    public class Factory : IFactory
    {
        private readonly IAssets _assets;

        private Factory(IAssets assets)
        {
            _assets = assets;
        }

        public async UniTask<GameObject> CreatePlayer(Vector3 payload)
        {
            GameObject tempPlayerPrefab = await _assets.InstantiatePlayer();
            tempPlayerPrefab.transform.SetPositionAndRotation(payload,Quaternion.identity);
            
            return tempPlayerPrefab;
        }
    }
}