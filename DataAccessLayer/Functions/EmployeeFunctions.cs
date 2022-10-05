using DataAccessLayer.Helpers;
using DataAccessLayer.DataContext;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.RequestVMs;
using DataAccessLayer.ViewModels.ResponseVMs;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Functions
{
    public class EmployeeFunctions : IEmployeeFunctions
    {
        public async Task<Employee> addEmployee(EmployeeAddRequestVM requestVM)
        {
            try
            {
                var data = EmployeeHelpers.ConvertAdd(requestVM);
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    await context.Employee.AddAsync(data);
                    await context.SaveChangesAsync();

                    return data;
                }
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nDataAccessLayer: EmployeeFunctions: addEmployee FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        public async Task<Employee?> updateEmployee(string id, EmployeeUpdateRequestVM requestVM)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    var data = context.Employee.FirstOrDefault(x => x.Id == id && x.Active == true);
                    if (data == null)
                    {
                        return null;
                        // throw new Exception($"\nDataAccessLayer: EmployeeFunctions: updateEmployee FAILED. {id} is not a valid id.");
                    }

                    data = EmployeeHelpers.ConvertUpdate(id, requestVM, data);
                    await context.SaveChangesAsync();
                    return data;
                }
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nDataAccessLayer: EmployeeFunctions: updateEmployee FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        public List<EmployeeGetAllResponseVM> getAllEmployee()
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    var allEmps = context.Employee.Where(x => x.Active == true).ToList();
                    List<EmployeeGetAllResponseVM> data = EmployeeHelpers.ConvertGetALL(allEmps);

                    return data;
                }
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nDataAccessLayer: EmployeeFunctions: getAllEmployee FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        public async Task<Employee?> deleteEmployee(string id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    var data = await context.Employee.FirstOrDefaultAsync(x => x.Id == id && x.Active == true);
                    if (data == null)
                    {
                        return null;
                        // throw new Exception($"\nDataAccessLayer: EmployeeFunctions: deleteEmployee FAILED. {id} is not a valid id.");
                    }

                    data = EmployeeHelpers.ConvertDelete(data);
                    context.SaveChanges();
                    return data;
                }
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nDataAccessLayer: EmployeeFunctions: deleteEmployee FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        public async Task<EmployeeGetResponseVM?> getEmployee(string id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    var emp = await context.Employee.FirstOrDefaultAsync(x => x.Id == id && x.Active == true);
                    if (emp == null)
                    {
                        return null;
                        // throw new Exception($"\nDataAccessLayer: EmployeeFunctions: getEmployee FAILED. {id} is not a valid id.");
                    }

                    var data = EmployeeHelpers.ConvertGet(emp);
                    return data;

                }
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nDataAccessLayer: EmployeeFunctions: getEmployee FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }
    }
}
