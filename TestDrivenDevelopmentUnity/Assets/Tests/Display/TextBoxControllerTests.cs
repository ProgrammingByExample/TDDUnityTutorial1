using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Production.Display;
using UnityEngine.TestTools;

namespace Tests.Display
{
    public class TextBoxControllerTests
    {
        [Test]
        public void UpdateText_DoesNotThrowAnException_WhenDisplayTextIsNullTest()
        {
            string givenText = "exampleText";
            
            // Arrange
            var tbcObject = new GameObject();
            tbcObject.AddComponent(typeof(TextBoxController));
            var textBoxController = tbcObject.GetComponent<TextBoxController>();

            // Act
            textBoxController.UpdateText(givenText);

            // Assert
            Assert.Pass();

            // Teardown
            Object.DestroyImmediate(tbcObject);
        }
        
        [Test]
        public void  UpdateText_SetsText_WhenGivenNoTimingTest()
        {
            string expectedText = "exampleText";
            
            // Arrange
            var tbcObject = new GameObject();
            tbcObject.AddComponent(typeof(TextBoxController));
            var textBoxController = tbcObject.GetComponent<TextBoxController>();

            var canvasObject = new GameObject();
            canvasObject.AddComponent(typeof(TMPro.TextMeshProUGUI));
            var textDisplay = canvasObject.GetComponent<TMPro.TextMeshProUGUI>();

            textBoxController.DisplayText = textDisplay;
            
            // Act
            textBoxController.UpdateText(expectedText);

            // Assert
            Assert.AreEqual(expectedText, textBoxController.DisplayText.text);
            
            // Teardown
            Object.DestroyImmediate(tbcObject);
            Object.DestroyImmediate(canvasObject);
        }
    }
}