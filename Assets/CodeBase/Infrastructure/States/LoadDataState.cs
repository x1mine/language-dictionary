using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.States {
    public class LoadDataState : IState {
        private readonly AppStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public LoadDataState(AppStateMachine stateMachine, AllServices services) {
            _stateMachine = stateMachine;
            _services = services;
        }


        public void Enter() {
            LoadData();
            _stateMachine.Enter<LoadSceneState, string>("Main");
        }

        public void Exit() { }

        private void LoadData() {
            //TODO: Load data
        }
    }
}