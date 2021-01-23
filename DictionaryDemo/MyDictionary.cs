using System;
using System.Linq;

namespace DictionaryDemo
{
    public class MyDictionary<TKey, TValue>
    {
        private TKey[] _key;
        private TValue[] _value;
        private TKey[] _tempKey;
        private TValue[] _tempValue;
        public MyDictionary()
        {
            _key = new TKey[0];
            _value = new TValue[0];
        }

        public void Add(TKey key, TValue value)
        {

            if (IsCheckKeyNull(key) == true)
            {
                throw new ArgumentNullException("Key değeri null olamaz!"); 
            }

            if (IsCheckKeyContains(key) == true)
            {
                throw new ArgumentException("Key değeri zaten mevcut");
            }

            AddItem(key, value);
        }
        //ekleme operasyonu tekrar kullanılabilir, DRY(Don't repeate yourself) prensibini de gözeterek  ve temiz bir görünüm olsun diye sadece bu class içerisinde kullanılmasına izin vererek method haline getirdim.
        private void AddItem(TKey key, TValue value)
        {
            _tempKey = _key;
            _tempValue = _value;

            _key = new TKey[_key.Length + 1];
            _value = new TValue[_value.Length + 1];

            for (int i = 0; i < _tempKey.Length; i++)
            {
                _key[i] = _tempKey[i];
                _value[i] = _tempValue[i];
            }
            _key[_key.Length - 1] = key;
            _value[_value.Length - 1] = value;
        }
        //Key değerimiz null olamayacağı için bunun önceden kontrolü sağlamak gerekiyor. 
        private bool IsCheckKeyNull(TKey key)
        {
            if (key == null)
            {
                return true;
            }
            var keyType = key.GetType();
            if (keyType == typeof(string) && string.IsNullOrEmpty(key.ToString()))
            {
                return true;
            }
            return false;
        }
        //Key değerimiz daha önce girilmiş bir key varmı onun kontrolünü sağlıyoruz. Çünkü key değerimiz unique(benzersiz) olması gerek
        private bool IsCheckKeyContains(TKey key)
        {
            if (_key.Contains(key))
            {
                return true;
            }
            return false;
        }

    }
}