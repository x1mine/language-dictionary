using UnityEngine;

namespace CodeBase.Infrastructure {
    public class AppBootstrapper : MonoBehaviour, ICoroutineRunner {
        private App _application;

        private void Awake() {
            _application = new App(this);
            _application.Boot();

            DontDestroyOnLoad(this);
        }
    }
}