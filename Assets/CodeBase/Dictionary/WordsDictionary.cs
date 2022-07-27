using System;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentData;

namespace CodeBase.Dictionary {
    public class WordsDictionary : ISavedData {
        public Dictionary<string, string> Dictionary { get; private set; }

        public WordsDictionary() =>
            Dictionary = new Dictionary<string, string>();

        public void AddWord(string word, string translation, Action onAdded = null) {
            if (Dictionary.ContainsKey(word) || word == string.Empty || translation == string.Empty) return;
            Dictionary.Add(word, translation);
            onAdded?.Invoke();
        }

        public void LoadData(UserData data) =>
            Dictionary = data.DictionaryData.Words;

        public void UpdateData(UserData data) =>
            data.DictionaryData.Words = Dictionary;
    }
}