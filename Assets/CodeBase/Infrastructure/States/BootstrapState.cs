using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentData;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.UI.Factory;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.States {
    public class BootstrapState : IState {
        private readonly AppStateMachine _stateMachine;
        private readonly AllServices _services;

        public BootstrapState(AppStateMachine stateMachine, SceneLoader sceneLoader, AllServices services) {
            _stateMachine = stateMachine;
            _services = services;

            RegisterServices();
        }

        public void Enter() {
            _stateMachine.Enter<LoadDataState>();
        }

        public void Exit() { }

        private void RegisterServices() {
            RegisterStaticDataService();
            _services.RegisterSingle<IAppFactory>(new AppFactory());
            _services.RegisterSingle<IPersistentDataService>(new PersistentDataService());
            _services.RegisterSingle<ISaveLoadService>(
                new SaveLoadService(_services.GetSingle<IPersistentDataService>(), _services.GetSingle<IAppFactory>()));
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.GetSingle<IAssetProvider>(),
                _services.GetSingle<IStaticDataService>(), _services.GetSingle<IPersistentDataService>()));
            _services.RegisterSingle<IWindowService>(new WindowService(_services.GetSingle<IUIFactory>()));
        }

        private void RegisterStaticDataService() {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadWindowsData();
            _services.RegisterSingle<IStaticDataService>(staticDataService);
        }
    }
}