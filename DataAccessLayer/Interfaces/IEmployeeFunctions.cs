using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.RequestVMs;
using DataAccessLayer.ViewModels.ResponseVMs;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeFunctions
    {
        Task<Employee> addEmployee(EmployeeAddRequestVM requestVM);
        Task<Employee?> updateEmployee(string id, EmployeeUpdateRequestVM requestVM);
        List<EmployeeGetAllResponseVM> getAllEmployee();
        Task<Employee?> deleteEmployee(string id);
        Task<EmployeeGetResponseVM?> getEmployee(string id);
    }
}
