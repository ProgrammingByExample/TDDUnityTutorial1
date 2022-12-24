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

        private GameObject imageObject;
        private RawImage rawImage;
        
        [SetUp]
        public void Setup()
        {
            this.tbcObject = new GameObject();
            this.textBoxController = this.tbcObject.AddComponent<TextBoxController>();

            this.canvasObject = new GameObject("Canvas");
            this.textDisplay = this.canvasObject.AddComponent<TMPro.TextMeshProUGUI>();
            
            this.imageObject = new GameObject("Just image");
            this.rawImage = this.imageObject.AddComponent<RawImage>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(this.tbcObject);
            Object.DestroyImmediate(this.canvasObject);
            Object.DestroyImmediate(this.imageObject);
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
            float expectedOpacity = 1;
            string givenText = "exampleText";
            
            // Arrange
            this.textBoxController.DisplayText = this.textDisplay;
            this.textBoxController.InteractionImage = this.rawImage;
            
            // Act
            this.textBoxController.UpdateText(givenText, ETextBoxInteraction.PlayerInteraction);

            // Assert
            Assert.AreEqual(expectedOpacity, this.textBoxController.InteractionImage.color.a);
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
            Assert.IsNotNull(this.textBoxController.InteractionImage);
            Assert.AreEqual(expectedOpacity, this.textBoxController.InteractionImage.color.a);
        }
    }
}