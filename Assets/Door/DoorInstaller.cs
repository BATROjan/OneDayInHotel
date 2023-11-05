using Zenject;

namespace Door
{
    public class DoorInstaller : Installer<DoorInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<DoorConfig>().AsSingle().NonLazy();
            Container.
        }
    }
}