using Game.Runtime.Core.Items;
using Game.Runtime.Managers;
using Zenject;

namespace Game.Runtime.Installer
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ItemFactory>().FromComponentInHierarchy().AsSingle();
        }
    }
}