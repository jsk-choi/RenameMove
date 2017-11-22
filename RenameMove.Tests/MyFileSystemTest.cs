using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameMove.Tests
{
    [TestClass]
    public class MyFileSystemTest
    {
        [TestMethod]
        public void MyFileSystemTest_()
        {
            var rootDir = @"C:\RenameMoveTest";

            // Arrange
            var fileSystem = new MockFileSystem(
                new Dictionary<string, MockFileData> {
                {
                    Path.Combine(rootDir, "myfile.txt"),
                    new MockFileData("Testing is meh.")
                },
                {
                    Path.Combine(rootDir, "jQuery.js"),
                    new MockFileData("some js")
                },
                {
                    Path.Combine(rootDir, "image.gif"),
                    new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 })
                }
            });

            var component = new MyFileSystem(fileSystem);

            // Act
            var result = component.GetFilesInDirectory(rootDir);

            // Assert
            Assert.IsTrue(result.Any());

        }
    }
}
