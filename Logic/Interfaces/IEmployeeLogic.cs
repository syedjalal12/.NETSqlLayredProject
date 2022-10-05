using DataAccessLayer.ViewModels.RequestVMs;
using DataAccessLayer.ViewModels.ResponseVMs;
using Logic.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IEmployeeLogic
    {
        Task<ActionResponseVM<string>> add(EmployeeAddRequestVM requestVM);
        Task<ActionResponseVM<bool?>> update(string id, EmployeeUpdateRequestVM requestVM);
        ActionResponseVM<List<EmployeeGetAllResponseVM>> getAll();
        Task<ActionResponseVM<bool>> delete(string id);
        Task<ActionResponseVM<EmployeeGetResponseVM?>> get(string id);
    }
}
