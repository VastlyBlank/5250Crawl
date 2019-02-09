using NUnit.Framework;

using Crawl.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    [TestFixture]
    public class CharacterUnitTests
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }

        [Test] // Used to get 100% code coverage prior to modifying ScaleLevel.
        public void Character_ScaleLevel_Level_1_Should_Pass()
        {
            // Arrange
            var Expected = true;
            var level = 1;

            var test = new Character();

            var Actual = test.ScaleLevel(level);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // This test checks that character cannot scale level 0.
        public void Character_ScaleLevel_Level_0_Should_Fail()
        {
            // Arrange
            var Expected = false;
            var level = 0;

            var test = new Character();

            var Actual = test.ScaleLevel(level);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // This is a redundant test to verify that character cannot scale above max level (20).
        public void Character_ScaleLevel_Level_Over_Max_Should_Fail()
        {
            // Arrange
            var Expected = false;
            var level = 47;

            var test = new Character();

            var Actual = test.ScaleLevel(level);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // This test checks that character cannot scale above max level (20).
        public void Character_ScaleLevel_Level_Over_20_Should_Fail()
        {
            // Arrange
            var Expected = false;
            var level = 21;

            var test = new Character();

            var Actual = test.ScaleLevel(level);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // This test checks that character cannot scale negative.
        public void Character_ScaleLevel_Level_Neg1_Should_Fail()
        {
            // Arrange
            var Expected = false;
            var level = -1;

            var test = new Character();

            var Actual = test.ScaleLevel(level);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // This test checks that character cannot scale to the same level.
        public void Character_ScaleLevel_Level_Same_Level_Should_Fail()
        {
            // Arrange
            var Expected = false;
            var level = 10;

            var test = new Character();
            test.Level = 10;

            var Actual = test.ScaleLevel(level);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // This test checks that character cannot scale to lower level.
        public void Character_ScaleLevel_Level_Lower_Level_Should_Fail()
        {
            // Arrange
            var Expected = false;
            var level = 8;

            var test = new Character();
            test.Level = 10;

            var Actual = test.ScaleLevel(level);

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // Tests that character's max health scales by 1 D10.
        public void Character_ScaleLevel_Level_1_Force_1_MaxHealth_Should_Return_1()
        {
            // Arrange
            var Expected = 2;
            var Fixed = 2;
            var Hit = 10;
            var level = 1;

            Crawl.Models.GameGlobals.SetForcedRandomNumbers(Fixed, Hit);

            var test = new Character();

            test.ScaleLevel(level);

            // Act
            var Actual = test.GetHealthMax();

            Crawl.Models.GameGlobals.ForceRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

        [Test] // Tests that character's max health scales by 2 D10.
        public void Character_ScaleLevel_Level_2_Force_1_MaxHealth_Should_Return_2()
        {
            // Arrange
            var Expected = 4;
            var Fixed = 2;
            var Hit = 10;
            var level = 2;

            Crawl.Models.GameGlobals.SetForcedRandomNumbers(Fixed, Hit);

            var test = new Character();

            test.ScaleLevel(level);

            // Act
            var Actual = test.GetHealthMax();

            Crawl.Models.GameGlobals.ForceRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(Expected, Actual, TestContext.CurrentContext.Test.Name);
        }

    }
}
