using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Failed
{
    public class CompareManager : MonoBehaviour
    {
        Text _resultMore;
        Text _resultLess;
        InputField _value;
        InputField _key;
        
        public int inputLimit = 18;

        private void Awake()
        {
            _resultMore = transform.Find("Result").Find("More").GetComponent<Text>();
            _resultLess = transform.Find("Result").Find("Less").GetComponent<Text>();
            _value = transform.Find("InputField").Find("Value").GetComponent<InputField>();
            _key = transform.Find("InputField").Find("Key").GetComponent<InputField>();
        }

        public void MakeResult()
        {
            if (_value.text == "") return;
            if (_key.text == "") return;
            if (_value.text.Length > inputLimit || _key.text.Length > inputLimit)
            {
                Reset();
                return;
            }
            if (_value.text.Length < _key.text.Length)
            {
                Reset();
                return;
            }
            
            _resultMore.text = CompareByKey(_value.text, _key.text, true);
            _resultLess.text = CompareByKey(_value.text, _key.text, false);
        }

        string CompareByKey(string valueText, string keyText, bool moreThanKey)
        {
            var resultCount = 0;
            var keyCount = keyText.Length;
            var key = Convert.ToDouble(keyText);

            for (int i = 0; i < valueText.Length; i++)
            {
                if (i + keyCount > valueText.Length) break;
                
                var subValue = valueText.Substring(i, keyCount);
                var value = Convert.ToDouble(subValue);
                
                if (moreThanKey)
                {
                    if (value > key) resultCount += 1;
                }
                else
                {
                    if (value <= key) resultCount += 1;
                }
            }

            return resultCount.ToString();
        }

        void Reset()
        {
            _value.text = "";
            _key.text = "";
            _resultMore.text = "";
            _resultLess.text = "";
        }
    }
}
