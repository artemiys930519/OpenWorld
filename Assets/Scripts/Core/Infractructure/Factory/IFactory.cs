using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Infractructure.Factory
{
    public interface IFactory
    {
        public UniTask<GameObject> CreatePlayer(Vector3 payload);
    }
}