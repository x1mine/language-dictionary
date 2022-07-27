using CodeBase.Data;
using CodeBase.Dictionary;
using CodeBase.Infrastructure.Services.PersistentData;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows {
    public abstract class WindowBase : MonoBehaviour {
        [SerializeField] private Button _closeButton;
        
        protected UserData Data => DataService.Data;
        protected WordsDictionary WordsDictionary;
        protected IPersistentDataService DataService;

        public void Construct(IPersistentDataService dataService, WordsDictionary wordsDictionary) {
            DataService = dataService;
            WordsDictionary = wordsDictionary;
        }

        private void Awake() =>
            OnAwake();

        private void Start() {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy() =>
            Cleanup();

        protected virtual void OnAwake() =>
            _closeButton.onClick.AddListener(() => Destroy(gameObject));

        protected virtual void Initialize() { }
        protected virtual void SubscribeUpdates() { }
        protected virtual void Cleanup() { }
    }
}