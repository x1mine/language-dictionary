using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.UI.Factory;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.States {
    public class BootstrapState : IState {
        private readonly AppStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(AppStateMachine stateMachine, SceneLoader sceneLoader, AllServices services) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter() {
            _stateMachine.Enter<LoadDataState>();
        }

        public void Exit() { }

        private void RegisterServices() {
            RegisterStaticDataService();
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.GetSingle<IAssetProvider>(),
                _services.GetSingle<IStaticDataService>()));
            _services.RegisterSingle<IWindowService>(new WindowService(_services.GetSingle<IUIFactory>()));
        }

        private void RegisterStaticDataService() {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadWindowsData();
            _services.RegisterSingle<IStaticDataService>(staticDataService);
        }
    }
}