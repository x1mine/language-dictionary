using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentData;
using CodeBase.Infrastructure.Services.SaveLoad;

namespace CodeBase.Infrastructure.States {
    public class LoadDataState : IState {
        private readonly AppStateMachine _stateMachine;
        private readonly IPersistentDataService _dataService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly SceneLoader _sceneLoader;

        public LoadDataState(AppStateMachine stateMachine, IPersistentDataService dataService, ISaveLoadService saveLoadService) {
            _stateMachine = stateMachine;
            _dataService = dataService;
            _saveLoadService = saveLoadService;
        }
        
        public void Enter() {
            LoadData();
            _stateMachine.Enter<LoadSceneState, string>("Main");
        }

        public void Exit() { }

        private void LoadData() => 
            _dataService.Data = _saveLoadService.LoadProgress() ?? NewData();

        private UserData NewData() {
            UserData data = new UserData();
            return data;
        }
    }
}