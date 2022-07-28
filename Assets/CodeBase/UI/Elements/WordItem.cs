using CodeBase.Dictionary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements {
    public class WordItem : MonoBehaviour {
        [SerializeField] private Button _deleteButton;
        [SerializeField] private TMP_Text _text;
        private WordsDictionary _wordsDictionary;
        private string _word;
        private string _translation;

        public void Construct(WordsDictionary dictionary, string word, string translation) {
            _wordsDictionary = dictionary;
            _word = word;
            _translation = translation;
            _text.text = $"{word} -> {translation}";
        }

        private void Awake() =>
            _deleteButton.onClick.AddListener(DeleteWord);

        private void DeleteWord() =>
            _wordsDictionary.DeleteWord(_word, onDeleted: OnDeleted);

        private void OnDeleted() =>
            Destroy(gameObject);
    }
}