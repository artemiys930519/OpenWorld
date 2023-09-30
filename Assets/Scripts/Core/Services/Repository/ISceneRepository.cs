using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.Repository
{
    public interface ISceneRepository
    {
        public void RegisterPlayer(GameObject player);
        public UniTask<GameObject> GetPlayer();
        public UniTask<T> GetComponentOnPlayer<T>();
    }
}