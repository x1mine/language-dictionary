using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows {
    public class AddWordWindow : WindowBase {
        [SerializeField] private TMP_InputField _foreignInputField;
        [SerializeField] private TMP_InputField _nativeInputField;
        [SerializeField] private TMP_Text _textLog;
        [SerializeField] private Button _addWordButton;

        protected override void OnAwake() {
            base.OnAwake();
            _addWordButton.onClick.AddListener(AddWord);
        }

        private void AddWord() =>
            WordsDictionary.AddWord(_foreignInputField.text, _nativeInputField.text, OnWordAdded);

        private void OnWordAdded() {
            _textLog.text = "Word added";
            _foreignInputField.text = string.Empty;
            _nativeInputField.text = string.Empty;
        }
    }
}