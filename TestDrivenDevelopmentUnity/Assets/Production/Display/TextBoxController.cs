using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Production.Display
{
    /// <summary>
    /// Controls the concept of a text-box which displays text to the player.
    /// </summary>
    public class TextBoxController : MonoBehaviour 
    {
        /// <summary>
        /// The text which is actually on the screen.
        /// </summary>
        public TMPro.TextMeshProUGUI DisplayText;

        /// <summary>
        /// An image displayed if the player is required to advance the text box.
        /// </summary>
        public RawImage InteractionImage;
        
        /// <summary>
        /// Updates the text within the text box.
        /// </summary>
        /// <param name="newValue"> The new value for the text box. </param>
        /// <param name="interaction">
        ///     How the text box should advance from this new state.
        ///     Default requires text box to handle the interaction.
        /// </param>
        public void UpdateText(
            string newValue, 
            ETextBoxInteraction interaction = ETextBoxInteraction.Automatic
            )
        {
            UpdateDisplayText(newValue);
            UpdateInteractionImage(interaction);
        }

        /// <summary>
        /// Directly updates the text in the box.
        /// </summary>
        /// <param name="newText"> New text to update. </param>
        private void UpdateDisplayText(string newText)
        {
            if (DisplayText is null)
            {
                Debug.LogWarning($"{nameof(DisplayText)} was null. Nothing was updated.");
                return;
            }
            
            DisplayText.text = newText;
        }

        /// <summary>
        /// Directly updates the interaction type.
        /// </summary>
        /// <param name="interaction"> How the text box updates. </param>
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