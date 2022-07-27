using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Data {
    public class DataSaver : MonoBehaviour {
        private void Awake() => 
            DontDestroyOnLoad(this);

        private void OnApplicationQuit() {
            AllServices.Container
                .GetSingle<ISaveLoadService>()?
                .SaveProgress();

        }
    }
}