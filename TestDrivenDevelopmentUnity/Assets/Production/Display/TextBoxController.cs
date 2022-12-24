using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Production.Display
{
    public class TextBoxController : MonoBehaviour 
    {
        public TMPro.TextMeshProUGUI DisplayText;

        public RawImage InteractionImage;
        
        public void UpdateText(
            string newValue, 
            ETextBoxInteraction interaction = ETextBoxInteraction.Automatic
            )
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