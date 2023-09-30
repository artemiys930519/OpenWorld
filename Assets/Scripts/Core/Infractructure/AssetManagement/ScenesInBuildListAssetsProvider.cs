using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.AssetManagement
{
    public class ScenesInBuildListAssetsProvider : ISceneAssets, IProgress<float>
    {
        private List<string> _currentSceneList = new();
        
        private Action _initializeComplete;

        public ScenesInBuildListAssetsProvider(Action initializeComplete = default)
        {
            _initializeComplete = initializeComplete;
            _initializeComplete?.Invoke();
        }

        public async UniTask<bool> LoadSceneAsync(string sceneName, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            var untc = new UniTaskCompletionSource<bool>();
            
            if(!_currentSceneList.Contains(sceneName))
                _currentSceneList.Add(sceneName);
            
            await SceneManager.LoadSceneAsync(sceneName, loadMode).ToUniTask(progress: this);
            untc.TrySetResult(true);

            return await untc.Task;
        }

        public void UnloadCurrentScene()
        {
            foreach (string scene in _currentSceneList)
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }

        public void Cleanup()
        {
            UnloadCurrentScene();
        }

        public void Report(float value)
        {
            if (value >= 1)
            {
                //SceneLoad?.Invoke();
            }
        }
    }
}