using Door;
using UnityEngine;
using Zenject;

public class ApplicationInstaller : MonoInstaller
{
    public Object prefab;
    public override void InstallBindings()
    {
        Container
            .Bind<Camera>()
            .FromComponentInNewPrefabResource("Main Camera")
            .AsSingle()
            .NonLazy();
        
        HallInstaller.Install(Container);
        
        DoorInstaller.Install(Container);
        
        Container
            .Bind<GameController>()
            .AsSingle()
            .NonLazy();

        Container.Bind<StartWindow>().FromComponentInNewPrefab(prefab).AsSingle().NonLazy();
    }
}