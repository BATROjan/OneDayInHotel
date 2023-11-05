using System.ComponentModel;
using Zenject;

namespace Player
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
           Container.Bind<PlayerController>().AsSingle().NonLazy();
           
           Container
                .BindMemoryPool<PlayerView, PlayerView.Pool>()
                .FromComponentInNewPrefabResource("Player")
                .AsCached()
                .NonLazy();
        }
    }
}