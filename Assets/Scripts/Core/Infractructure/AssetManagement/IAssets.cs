using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public interface IAssets
    {
        UniTask<GameObject> InstantiatePlayer(Vector3 at);
    }
}