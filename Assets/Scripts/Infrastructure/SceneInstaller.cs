using System.Globalization;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using UnityEngine.Serialization;
using Words;
using Zenject;

namespace Infrastructure
{
    public class SceneInstaller: MonoInstaller
    {
        public MainMenu MainMenu;
        public LevelLoader LevelLoader;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<AllWordsList>().
                AsSingle().
                NonLazy();            
            
            var levelLoader = Container.
                InstantiatePrefabForComponent<LevelLoader>(LevelLoader);
            levelLoader.gameObject.SetActive(false);
            
            Container.Bind<LevelLoader>()
                .FromInstance(levelLoader)
                .AsSingle();
            
            var mainMenu = Container.
                InstantiatePrefabForComponent<MainMenu>(MainMenu);
            
            Container.Bind<MainMenu>()
                .FromInstance(mainMenu)
                .AsSingle();
            
            InstallStateMachine();
        }
        private void InstallStateMachine()
        {
            Container
                .BindInterfacesAndSelfTo<GameStartState>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<MainMenuState>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<LoadLevelState>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<GameStateMachine>()
                .AsSingle()
                .NonLazy();
        }
    }
}