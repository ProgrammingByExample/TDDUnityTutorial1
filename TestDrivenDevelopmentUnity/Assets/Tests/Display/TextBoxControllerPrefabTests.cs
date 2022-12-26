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
    public class TextBoxControllerPrefabTests
    {
        private GameObject tbcObject;
        private TextBoxController textBoxController;

        [SetUp]
        public void Setup()
        {
            this.tbcObject = MonoBehaviour.Instantiate(
                Resources.Load<GameObject>("Display/TextBox"));
            this.textBoxController = this.tbcObject.GetComponent<TextBoxController>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(this.tbcObject);
        }

        [Test]
        public void UpdateText_SetsTextTest()
        {
            string expectedText = "exampleText";
            
            // Arrange

            // Act
            this.textBoxController.UpdateText(expectedText);

            // Assert
            Assert.AreEqual(expectedText, this.textBoxController.DisplayText.text);
        }

        [Test]
        public void  UpdateText_ShowsPlayerButtonMarker_WhenGivenPlayerInteractionTest()
        {
            float expectedOpacity = 1;
            string givenText = "exampleText";
            
            // Arrange

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

            // Act
            this.textBoxController.UpdateText(givenText);

            // Assert
            Assert.AreEqual(expectedOpacity, this.textBoxController.InteractionImage.color.a);
        }
    }
}