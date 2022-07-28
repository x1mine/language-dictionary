using CodeBase.Extensions;
using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.UI.Windows {
    public class WordsListWindow : WindowBase {
        [SerializeField] private WordItem _wordItem;
        [SerializeField] private Transform _content;

        protected override void Initialize() =>
            UpdateList();

        private void UpdateList() {
            foreach (var pair in WordsDictionary.Dictionary) {
                Instantiate(_wordItem, _content)
                    .With(item => item.Construct(WordsDictionary, pair.Key, pair.Key));
            }
        }
    }
}