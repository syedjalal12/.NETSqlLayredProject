using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.ResponseVMs;
using Logic.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ILogicHelper
    {
        ActionResponseVM<string> convertAdd(Employee emp);
        ActionResponseVM<bool?> convertUpdate(string id, Employee? emp);
        ActionResponseVM<List<EmployeeGetAllResponseVM>> convertGetAll(List<EmployeeGetAllResponseVM> emp);
        ActionResponseVM<bool> convertDelete(string id, Employee? emp);
        ActionResponseVM<EmployeeGetResponseVM?> ConvertGet(string id, EmployeeGetResponseVM emp);
    }
}
