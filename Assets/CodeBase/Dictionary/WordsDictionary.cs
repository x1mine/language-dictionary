using System.Collections.Generic;
using System.Linq;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentData;
using UnityEngine;

namespace CodeBase.Dictionary {
    public class WordsDictionary : ISavedData {
        private Dictionary<string, string> _dictionary;

        public WordsDictionary() =>
            _dictionary = new Dictionary<string, string>();

        public void AddWord(string word, string translation) {
            if (_dictionary.ContainsKey(word)) return;
            
            Debug.Log($"{word} -> {translation}");
            _dictionary.Add(word, translation);
        }

        public void LoadData(UserData data) {
            _dictionary = data.DictionaryData.Words.ToDictionary(x => x.Key, x => x.Value);
        }

        public void UpdateData(UserData data) {
            data.DictionaryData.Words = _dictionary.ToDictionary(x => x.Key, x => x.Value);
            Debug.Log("Data saved");
        }
    }
}