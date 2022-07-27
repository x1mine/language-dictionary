using CodeBase.Extensions;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Windows {
    public class WordsListWindow : WindowBase {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Transform _content;

        protected override void Initialize() =>
            UpdateList();

        private void UpdateList() {
            foreach (var pair in WordsDictionary.Dictionary) {
                Instantiate(_text, _content).With(text => text.text = $"{pair.Key} -> {pair.Value}");
            }
        }
    }
}