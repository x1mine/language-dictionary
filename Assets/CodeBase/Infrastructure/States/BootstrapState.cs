using CodeBase.Infrastructure.Services;

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

        private void RegisterServices() { }
    }
}