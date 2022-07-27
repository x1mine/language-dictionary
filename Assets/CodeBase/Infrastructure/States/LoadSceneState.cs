using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.States {
    public class LoadSceneState : IPayloadedState<string> {
        private readonly AppStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public LoadSceneState(AppStateMachine stateMachine, SceneLoader sceneLoader, AllServices services) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
        }

        public void Enter(string sceneName) {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() { }

        private void OnLoaded() {
            //TODO: Init scene
        }
    }
}