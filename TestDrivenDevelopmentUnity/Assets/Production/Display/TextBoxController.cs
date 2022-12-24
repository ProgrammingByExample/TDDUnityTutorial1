using System;
using UnityEngine;
using UnityEngine.UI;

namespace Production.Display
{
    public class TextBoxController : MonoBehaviour 
    {
        public TMPro.TextMeshProUGUI DisplayText;
        
        public void UpdateText(string newValue)
        {
            if (DisplayText is null)
            {
                Debug.LogWarning($"{nameof(DisplayText)} was null. Nothing was updated.");
                return;
            }
            
            DisplayText.text = newValue;
        }
    }
}