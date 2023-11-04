using System.ComponentModel;
using Zenject;

namespace Player
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<PlayerView, PlayerView.Pool>()
                .FromComponentInNewPrefabResource("Player")
                .AsSingle()
                .NonLazy();
        }
    }
}