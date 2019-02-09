using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.GameEngine
{
    [TestFixture]
    public class HelperEngineUnitTests
    {
        [Test] // This test is to check that the for loop for dice roll is being hit.
        public void RollDice_Roll_1_Dice_10_Should_Pass()
        {            
            // Arrange
            var Roll = 1;
            var Dice = 10;
            var Expected = 1;

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.NotZero(Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // This test checks that the for loop for dice roll is being hit.
        public void RollDice_Roll_2_Dice_10_Should_Pass()
        {
            // Arrange
            var Roll = 2;
            var Dice = 10;
            var Expected = 4;

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);
                      
            // Assert - Only care that something was rolled, not specific value.
            Assert.NotZero(Actual, TestContext.CurrentContext.Test.Name);
        }
         
        [Test] // This test checks that rolling 0 dice returns 0.
        public void RollDice_Roll_0_Dice_10_Should_Fail()
        {
            // Arrange
            var Roll = 0;
            var Dice = 10;
            var Expected = 0;

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // This test checks that negative roll returns 0.
        public void RollDice_Roll_Neg1_Dice_10_Should_Fail()
        {
            // Arrange
            var Roll = -1;
            var Dice = 10;
            var Expected = 0;

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // Tests that result of dice cannot have negative values.
        public void RollDice_Roll_1_Dice_Neg1_Should_Fail()
        {
            // Arrange
            var Roll = 1;
            var Dice = -1;
            var Expected = 0;

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // Tests that dice cannot have zero outcomes.
        public void RollDice_Roll_1_Dice_Zero_Should_Fail()
        {
            // Arrange
            var Roll = 1;
            var Dice = 0;
            var Expected = 0;

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // Verifies that forcing roll works for at least one die.
        public void RollDice_Roll_1_Dice_10_Fixed_5_Should_Return_5()
        { 
            // Arrange
            var Roll = 1;
            var Dice = 10;
            var Expected = 5;
            var Fixed = 5;
            var Hit = 10;

            Crawl.Models.GameGlobals.SetForcedRandomNumbers(Fixed, Hit);

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            Crawl.Models.GameGlobals.ForceRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // Verifies that forcing a roll value works for multiple die.
        public void RollDice_Roll_3_Dice_10_Fixed_5_Should_Return_15()
        {
            // Arrange
            var Roll = 3;
            var Dice = 10;
            var Expected = 15;
            var Fixed = 5;
            var Hit = 10;

            Crawl.Models.GameGlobals.SetForcedRandomNumbers(Fixed, Hit);

            // Act
            var Actual = Crawl.GameEngine.HelperEngine.RollDice(Roll, Dice);

            Crawl.Models.GameGlobals.ForceRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

    }
}
