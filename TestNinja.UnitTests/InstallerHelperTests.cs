using System;
using System.Net;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;
        private string _setupDestinationPath;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _setupDestinationPath = "downloads";
            _installerHelper = new InstallerHelper(_setupDestinationPath, _fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_WhenCalled_CallFileDownloader()
        {
            _installerHelper.DownloadInstaller("customer", "installer");
            _fileDownloader.Verify(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()));
        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.True);
        }

        [Test]
        public void DownloadInstaller_DownloadFailed_ReturnFalse()
        {
            _fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            var result = _installerHelper.DownloadInstaller("a", "b");
            
            Assert.That(result, Is.False);
        }
    }
}