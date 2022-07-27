using CodeBase.Infrastructure.Services;
using CodeBase.UI.Factory;

namespace CodeBase.Infrastructure.States {
    public class LoadSceneState : IPayloadedState<string> {
        private readonly AppStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly AllServices _services;

        public LoadSceneState(AppStateMachine stateMachine, SceneLoader sceneLoader, IUIFactory uiFactory) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName) {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() { }

        private void OnLoaded() =>
            InitUIRoot();

        private void InitUIRoot() =>
            _services.GetSingle<IUIFactory>().CreateUIRoot();
    }
}