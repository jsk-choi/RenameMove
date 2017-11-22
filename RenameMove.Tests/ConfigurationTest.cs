using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameMove.Tests
{
    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void Configuration_SettingExists()
        {
            // Arrange / Act
            var settings = new Configuration();

            // Act
            var result = 
                settings.PathsToProcess.Where(x => x != string.Empty).Count() > 0 && 
                settings.VideoFileTypeExtensions.Where(x => x != string.Empty).Any();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
