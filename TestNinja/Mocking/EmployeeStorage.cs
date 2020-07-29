using System;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public async Task DeleteEmployee(int employeeId)
        {
            using var dbContext = new EmployeeContext();
            
            var employee = await dbContext.Employees.FindAsync(employeeId);
            if (employee == null)
                throw new EmployeeNotExistException(employeeId);

            dbContext.Employees.Remove(employee);
            await dbContext.SaveChangesAsync();
        }
    }

    public class EmployeeNotExistException : Exception
    {
        public EmployeeNotExistException(int employeeId) : base($"Employee with id {employeeId} doesn't exist")
        {
        }
    }
}