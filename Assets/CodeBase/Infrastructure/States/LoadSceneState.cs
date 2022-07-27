using CodeBase.Dictionary;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentData;
using CodeBase.UI.Factory;

namespace CodeBase.Infrastructure.States {
    public class LoadSceneState : IPayloadedState<string> {
        private readonly AppStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly AllServices _services;
        private readonly IAppFactory _appFactory;
        private readonly IPersistentDataService _dataService;

        public LoadSceneState(AppStateMachine stateMachine, SceneLoader sceneLoader, IUIFactory uiFactory,
            IAppFactory appFactory, IPersistentDataService dataService) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _appFactory = appFactory;
            _dataService = dataService;
        }

        public void Enter(string sceneName) {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() { }

        private void OnLoaded() {
            InitUIRoot(InitDictionary());
            InformProgressReaders();
        }

        private WordsDictionary InitDictionary() => 
            _appFactory.CreateDictionary();

        private void InformProgressReaders() {
            foreach (var reader in _appFactory.DataReaders) {
                reader.LoadData(_dataService.Data);
            }
        }

        private void InitUIRoot(WordsDictionary wordsDictionary) =>
            _uiFactory.CreateUIRoot(wordsDictionary);
    }
}