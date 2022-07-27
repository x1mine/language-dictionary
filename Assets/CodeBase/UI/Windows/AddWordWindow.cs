using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows {
    public class AddWordWindow : WindowBase {
        [SerializeField] private TMP_InputField _foreignInputField;
        [SerializeField] private TMP_InputField _nativeInputField;
        [SerializeField] private Button _addWordButton;

        protected override void OnAwake() {
            base.OnAwake();
            _addWordButton.onClick.AddListener(AddWord);
        }

        private void AddWord() {
            Dictionary.AddWord(_foreignInputField.text, _nativeInputField.text);
            CleanInputFields();
        }

        private void CleanInputFields() {
            _foreignInputField.text = string.Empty;
            _nativeInputField.text = string.Empty;
        }
    }
}