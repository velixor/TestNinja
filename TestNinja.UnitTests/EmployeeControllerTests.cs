using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;
        private Mock<IEmployeeStorage> _employeeStorage;

        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
        }

        [Test]
        public async Task DeleteEmployee_EmployeeExist_ReturnActionResult()
        {
            var result = await _employeeController.DeleteEmployee(1);
            
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }

        [Test]
        public async Task DeleteEmployee_WhenCalled_DeleteEmployee()
        {
            await _employeeController.DeleteEmployee(1);
            _employeeStorage.Verify(es => es.DeleteEmployee(1));
        }
    }
}