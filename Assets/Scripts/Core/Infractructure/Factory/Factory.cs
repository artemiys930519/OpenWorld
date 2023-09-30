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

        public async UniTask<GameObject> CreatePlayer(Vector3 at)
        {
            GameObject tempPlayer = await _assets.InstantiatePlayer();
            tempPlayer.transform.position = at;
            return tempPlayer;
        }
    }
}