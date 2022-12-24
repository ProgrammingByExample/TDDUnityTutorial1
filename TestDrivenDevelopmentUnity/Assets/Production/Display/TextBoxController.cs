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
            UpdateDisplayText(newValue);
            UpdateInteractionImage(interaction);
        }

        private void UpdateDisplayText(string newText)
        {
            if (DisplayText is null)
            {
                Debug.LogWarning($"{nameof(DisplayText)} was null. Nothing was updated.");
                return;
            }
            
            DisplayText.text = newText;
        }

        private void UpdateInteractionImage(ETextBoxInteraction interaction)
        {
            if (InteractionImage is null)
            {
                Debug.LogWarning($"{nameof(InteractionImage)} was null. Nothing was updated.");
                return;
            }

            Color current = InteractionImage.color;
            if (interaction == ETextBoxInteraction.Automatic)
            {
                current.a = 0;
            }
            else
            {
                current.a = 1;
            }
            
            InteractionImage.color = current;
        }
    }
}