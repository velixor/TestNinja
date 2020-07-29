using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IEmployeeStorage
    {
        Task DeleteEmployee(int employeeId);
    }
}