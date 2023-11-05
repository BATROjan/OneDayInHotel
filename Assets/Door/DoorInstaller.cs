using Zenject;

namespace Door
{
    public class DoorInstaller : Installer<DoorInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<DoorConfig>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<DoorController>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<DoorView, DoorView.Pool>()
                .WithInitialSize(5)
                .FromComponentInNewPrefabResource("Door")
                .UnderTransformGroup("Hall");
        }
    }
}