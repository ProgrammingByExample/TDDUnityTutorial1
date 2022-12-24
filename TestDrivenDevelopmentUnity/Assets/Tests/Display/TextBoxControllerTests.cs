using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using Production.Display;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Tests.Display
{
    public class TextBoxControllerTests
    {
        private GameObject tbcObject;
        private TextBoxController textBoxController;
        
        private GameObject canvasObject;
        private TMPro.TextMeshProUGUI textDisplay;
        private RawImage rawImage;
        
        [SetUp]
        public void Setup()
        {
            this.tbcObject = new GameObject();
            this.tbcObject.AddComponent(typeof(TextBoxController));
            this.textBoxController = this.tbcObject.GetComponent<TextBoxController>();
            
            this.canvasObject = new GameObject();
            this.canvasObject.AddComponent(typeof(TMPro.TextMeshProUGUI));
            this.textDisplay = canvasObject.GetComponent<TMPro.TextMeshProUGUI>();
            this.rawImage = canvasObject.GetComponent<RawImage>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(this.tbcObject);
            Object.DestroyImmediate(this.canvasObject);
        }
        
        [Test]
        public void UpdateText_DoesNotThrowAnException_WhenDisplayTextIsNullTest()
        {
            string givenText = "exampleText";
            
            // Arrange

            // Act
            this.textBoxController.UpdateText(givenText);

            // Assert
            Assert.Pass();
        }
        
        [Test]
        public void  UpdateText_SetsTextTest()
        {
            string expectedText = "exampleText";
            
            // Arrange
            this.textBoxController.DisplayText = this.textDisplay;
            
            // Act
            this.textBoxController.UpdateText(expectedText);

            // Assert
            Assert.AreEqual(expectedText, this.textDisplay.text);
        }
        
        [Test]
        public void  UpdateText_DoesNothing_WhenNoRawImageIsGivenTest()
        {
            string givenText = "exampleText";
            
            // Arrange
            this.textBoxController.DisplayText = this.textDisplay;

            // Act
            this.textBoxController.UpdateText(givenText, ETextBoxInteraction.PlayerInteraction);

            // Assert
            Assert.Pass();
        }
        
        [Test]
        public void  UpdateText_ShowsPlayerButtonMarker_WhenGivenPlayerInteractionTest()
        {
            float expectedOpacity = 255;
            string givenText = "exampleText";
            
            // Arrange
            this.textBoxController.DisplayText = this.textDisplay;
            this.textBoxController.InteractionImage = this.rawImage;
            
            // Act
            this.textBoxController.UpdateText(givenText, ETextBoxInteraction.PlayerInteraction);

            // Assert
            Assert.AreEqual(expectedOpacity, this.rawImage.color.a);
        }
        
        [Test]
        public void  UpdateText_HidesPlayerButtonMarker_WhenGivenAutomaticInteractionTest()
        {
            float expectedOpacity = 0;
            string givenText = "exampleText";
            
            // Arrange
            this.textBoxController.DisplayText = this.textDisplay;
            this.textBoxController.InteractionImage = this.rawImage;
            
            // Act
            this.textBoxController.UpdateText(givenText);

            // Assert
            Assert.AreEqual(expectedOpacity, this.rawImage.color.a);
        }
    }
}