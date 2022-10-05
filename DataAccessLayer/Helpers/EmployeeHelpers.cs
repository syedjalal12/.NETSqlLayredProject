using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.RequestVMs;
using DataAccessLayer.ViewModels.ResponseVMs;

namespace DataAccessLayer.Helpers
{
    public static class EmployeeHelpers
    {
        public static Employee ConvertAdd(EmployeeAddRequestVM vm)
        {
            System.Guid guid = System.Guid.NewGuid();
            var model = new Employee
            {
                Id = guid.ToString(),
                //image = vm.image,
                Name = vm.name,
                Email = vm.email,
                Designation = vm.designation,
                Department = vm.department,
                Position = vm.position,
                Active = true
            };
            return model;
        }

        public static Employee ConvertUpdate(string id, EmployeeUpdateRequestVM vm, Employee currentEmp)
        {
            //currentEmp.image = vm.image;
            currentEmp.Name = vm.name;
            currentEmp.Email = vm.email;
            currentEmp.Designation = vm.designation;
            currentEmp.Department = vm.department;
            currentEmp.Position = vm.position;

            return currentEmp;
        }

        public static List<EmployeeGetAllResponseVM> ConvertGetALL(List<Employee> vm)
        {
            var model = new List<EmployeeGetAllResponseVM>();

            foreach (var data in vm)
            {
                var emp = new EmployeeGetAllResponseVM
                {
                    id = data.Id,
                    //image = data.image,
                    name = data.Name,
                    email = data.Email,
                    designation = data.Designation,
                    department = data.Department,
                    position = data.Position
                };
                model.Add(emp);
            }
            return model;
        }

        public static Employee ConvertDelete(Employee vm)
        {
            vm.Active = false;
            return vm;
        }

        public static EmployeeGetResponseVM ConvertGet(Employee vm)
        {
            var model = new EmployeeGetResponseVM
            {
                id = vm.Id,
                //image = vm.image,
                name = vm.Name,
                email = vm.Email,
                designation = vm.Designation,
                department = vm.Department,
                position = vm.Position,

            };
            return model;
        }
    }
}
