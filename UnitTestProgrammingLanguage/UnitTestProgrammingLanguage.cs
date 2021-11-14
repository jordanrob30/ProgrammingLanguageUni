using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingLanguageAssignment;
using System;
using System.Drawing;

namespace UnitTestProgrammingLanguage
{
    [TestClass]
    public class UnitTestProgrammingLanguage
    {
        /// <summary>
        /// Test to ensure Rectangle::validateArguments() throws an error when invalid parameters are passed to it
        /// </summary>
        [TestMethod]
        public void RectangleInvalidParameterValidation()
        {
            Command command = command = new ProgrammingLanguageAssignment.Rectangle();

            string[] args = { "badVar", "2" };

            string response = command.validateArguments(args);

            Assert.AreEqual("Invalid arguments, expecting rectangle <width>,<height>", response);
        }

        /// <summary>
        /// test to ensure that Rectangle::validateArguments() returns a blank string when valid arguments are passed to it
        /// </summary>
        [TestMethod]
        public void RectangleValidParameterValidation()
        {
            Command command = command = new ProgrammingLanguageAssignment.Rectangle();

            string[] args = { "10", "2" };

            string response = command.validateArguments(args);

            Assert.AreEqual("", response);
        }

        /// <summary>
        /// Test to ensure command parser returns expected results with multiple arguments
        /// </summary>
        [TestMethod]
        public void CommandParserReturnsCorrectResultsMultipleArguments()
        {
            CommandParser parser = new CommandParser("rectangle 20,10");
            string[] expectedArgs = { "20", "10" };

            Assert.AreEqual(parser.command, "rectangle");
            Assert.AreEqual(parser.args[0], expectedArgs[0]);
            Assert.AreEqual(parser.args[1], expectedArgs[1]);
        }

        // <summary>
        /// Test to ensure command parser returns expected results with single arument
        /// </summary>
        [TestMethod]
        public void CommandParserReturnsCorrectResultsSingleArgument()
        {
            CommandParser parser = new CommandParser("fill on");
            string[] expectedArgs = { "on" };

            Assert.AreEqual(parser.command, "fill");
            Assert.AreEqual(parser.args[0], expectedArgs[0]);
        }

        /// <summary>
        /// Test to ensure Circle::validateArguments() throws an error when invalid parameters are passed to it
        /// </summary>
        [TestMethod]
        public void CircleInvalidParameterValidation()
        {
            Command command = command = new Circle();

            string[] args = { "badVar", "2" };

            string response = command.validateArguments(args);

            Assert.AreEqual("Invalid arguments, expecting circle <radius>", response);
        }

        /// <summary>
        /// test to ensure that Circle::validateArguments() returns a blank string when valid arguments are passed to it
        /// </summary>
        [TestMethod]
        public void CircleValidParameterValidation()
        {
            Command command = command = new Circle();

            string[] args = { "10" };

            string response = command.validateArguments(args);

            Assert.AreEqual("", response);
        }

        /// <summary>
        /// Test to ensure Triangle::validateArguments() throws an error when invalid parameters are passed to it
        /// </summary>
        [TestMethod]
        public void TriangleInvalidParameterValidation()
        {
            Command command = command = new Triangle();

            string[] args = { "badVar", "2" };

            string response = command.validateArguments(args);

            Assert.AreEqual("Invalid arguments, expecting triangle <width>,<height>", response);
        }

        /// <summary>
        /// test to ensure that Triangle::validateArguments() returns a blank string when valid arguments are passed to it
        /// </summary>
        [TestMethod]
        public void TriangleValidParameterValidation()
        {
            Command command = command = new Triangle();

            string[] args = { "10", "20" };

            string response = command.validateArguments(args);

            Assert.AreEqual("", response);
        }

        /// <summary>
        /// Test to ensure MoveTo::validateArguments() throws an error when invalid parameters are passed to it
        /// </summary>
        [TestMethod]
        public void MoveToInvalidParameterValidation()
        {
            Command command = command = new MoveTo();

            string[] args = { "badVar", "2" };

            string response = command.validateArguments(args);

            Assert.AreEqual("Invalid arguments, expecting moveTo <X>,<Y>", response);
        }

        /// <summary>
        /// test to ensure that Triangle::validateArguments() returns a blank string when valid arguments are passed to it
        /// </summary>
        [TestMethod]
        public void MoveToValidParameterValidation()
        {
            Command command = command = new MoveTo();

            string[] args = { "10", "20" };

            string response = command.validateArguments(args);

            Assert.AreEqual("", response);
        }

        /// <summary>
        /// Test to ensure that MoveTo::Execute() updates the provided canvas object
        /// </summary>
        [TestMethod]
        public void MoveToUpdatesCanvasValues()
        {
            Bitmap OutputBm = new Bitmap(640, 480);
            Canvas canvas = new ProgrammingLanguageAssignment.Canvas(Graphics.FromImage(OutputBm));
            Command command = command = new MoveTo();
            string[] args = { "200", "300" };

            command.ParseArguments(args);
            command.Execute(canvas);

            Assert.AreEqual(200, canvas.xPos);
            Assert.AreEqual(300, canvas.yPos);
        }

        /// <summary>
        /// Test to ensure that Reset::Execute() updates the x,y values to be 0,0
        /// </summary>
        [TestMethod]
        public void ResetUpdatesCanvasValues()
        {
            Bitmap OutputBm = new Bitmap(640, 480);
            Canvas canvas = new ProgrammingLanguageAssignment.Canvas(Graphics.FromImage(OutputBm));
            Command command = command = new Reset();

            command.Execute(canvas);

            Assert.AreEqual(0, canvas.xPos);
            Assert.AreEqual(0, canvas.yPos);
        }

        /// <summary>
        /// Test to ensure that Reset::Execute() updates the x,y values to be 0,0
        /// </summary>
        [TestMethod]
        public void PenColourUpdatesCanvasValues()
        {
            Bitmap OutputBm = new Bitmap(640, 480);
            Canvas canvas = new ProgrammingLanguageAssignment.Canvas(Graphics.FromImage(OutputBm));
            Command command = command = new PenColour();

            string[] args = { "red" };

            command.ParseArguments(args);
            command.Execute(canvas);

            Assert.AreEqual(canvas.Pen.Color, Color.Red);
        }
    }
}
