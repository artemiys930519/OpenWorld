using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Infractructure.AssetManagement
{
    public interface IAssets
    {
        UniTask<GameObject> InstantiatePlayer();
    }
}