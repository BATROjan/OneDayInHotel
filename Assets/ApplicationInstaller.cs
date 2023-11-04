using UnityEngine;
using Zenject;

public class ApplicationInstaller : MonoInstaller
{
    public Object prefab;
    public override void InstallBindings()
    {
        HallInstaller.Install(Container);
        
        Container
            .Bind<GameController>()
            .AsSingle()
            .NonLazy();

        Container.Bind<testCub>().FromComponentInNewPrefab(prefab).AsSingle().NonLazy();
    }
}