using Core.Events;
using Core.Infractructure.Factory;
using Core.Network;
using Core.Services.Repository;
using Infrastructure.AssetManagement;
using Infrastructure.SceneLoader;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using IFactory = Core.Infractructure.Factory.IFactory;

namespace Installers
{
    public class StandaloneSceneInstaller: MonoInstaller<StandaloneSceneInstaller>
    {
        [SerializeField] private PrefabSettings _prefabSettings;
        [SerializeField] private StandaloneSceneComposition _standaloneSceneComposition;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<RaisePortalSignal>();

            Container.Bind<ISceneRepository>().To<SceneRepository>().AsSingle();
            Container.Bind<ISceneComposition>().FromInstance(_standaloneSceneComposition);
            Container.Bind<ISceneAssets>().To<ScenesInBuildListAssetsProvider>().AsTransient();
            Container.Bind<IAssets>().To<ScriptableObjectAssets>().AsTransient().WithArguments(_prefabSettings);
            Container.Bind<IFactory>().To<Factory>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsTransient();
        }
    } 
}