using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Data {
    public class DataSaver : MonoBehaviour {
        private ISaveLoadService _saveLoadService;

        private void Awake() {
            DontDestroyOnLoad(this);
            _saveLoadService = AllServices.Container.GetSingle<ISaveLoadService>();
        }

        private void OnApplicationPause(bool pauseStatus) =>
            _saveLoadService.SaveProgress();
    }
}