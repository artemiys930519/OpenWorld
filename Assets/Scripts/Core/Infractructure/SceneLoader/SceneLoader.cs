using Core.Infractructure.AssetManagement;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ISceneAssets _sceneAssets;
        
        public SceneLoader(ISceneAssets sceneAssets)
        {
            _sceneAssets = sceneAssets;
        }
        
        public async UniTask<bool> LoadSceneAsync(string sceneName, LoadSceneMode loadMode = LoadSceneMode.Single)
        { 
            return await _sceneAssets.LoadSceneAsync(sceneName, loadMode);
        }

        public void UnloadCurrentScene()
        {
            _sceneAssets.UnloadCurrentScene();
        }

        public void Cleanup()
        {
            _sceneAssets.Cleanup();
        }
    }
}