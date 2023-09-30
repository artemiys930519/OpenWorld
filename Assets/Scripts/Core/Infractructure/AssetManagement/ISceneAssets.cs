using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.AssetManagement
{
    public interface ISceneAssets
    {
        public UniTask<bool> LoadSceneAsync(string sceneName, LoadSceneMode loadMode = LoadSceneMode.Single);
        public void UnloadCurrentScene();
        public void Cleanup();
    }
}