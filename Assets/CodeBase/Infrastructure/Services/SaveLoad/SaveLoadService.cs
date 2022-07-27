using CodeBase.Data;
using CodeBase.Extensions;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad {
    public class SaveLoadService : ISaveLoadService {
        private const string DataKey = "UserData";
        private readonly IPersistentDataService _dataService;
        private readonly IAppFactory _appFactory;

        public SaveLoadService(IPersistentDataService dataService, IAppFactory appFactory) {
            _dataService = dataService;
            _appFactory = appFactory;
        }

        public void SaveProgress() {
            foreach (var writer in _appFactory.DataWriters)
                writer.UpdateData(_dataService.Data);

            Debug.Log(_dataService.Data.DictionaryData.Words.Count);

            PlayerPrefs.SetString(DataKey, _dataService.Data.ToJson());
        }

        public UserData LoadProgress() {
            Debug.Log(PlayerPrefs.GetString(DataKey));
            return PlayerPrefs.GetString(DataKey)?.ToDeserialized<UserData>();
        }
    }
}