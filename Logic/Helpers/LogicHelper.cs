using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.ResponseVMs;
using Logic.Interfaces;
using Logic.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Helpers
{
    public class LogicHelper: ILogicHelper
    {
        public ActionResponseVM<string> convertAdd(Employee emp)
        {
            var actionResponse = new ActionResponseVM<string>
            {
                Data = emp.Id,
                Successful = true,
                CodeStatus = 200,
                Message = "SUCCESS"
            };
            return actionResponse;
        }

        public ActionResponseVM<bool?> convertUpdate(string id, Employee? emp)
        {
            var actionResponse = new ActionResponseVM<bool?>();

            if (emp == null)
            {
                actionResponse.Data = null;
                actionResponse.Successful = false;
                actionResponse.CodeStatus = 404;
                actionResponse.Message = $"Id: '{id}' not found";
                return actionResponse;
            }
            actionResponse.Data = true;
            actionResponse.Successful = true;
            actionResponse.CodeStatus = 200;
            actionResponse.Message = "SUCCESS";
            return actionResponse;
        }

        public ActionResponseVM<List<EmployeeGetAllResponseVM>> convertGetAll(List<EmployeeGetAllResponseVM> emp)
        {

            var actionResponse = new ActionResponseVM<List<EmployeeGetAllResponseVM>>
            {
                Data = emp,
                Successful = true,
                CodeStatus = 200,
                Message = "SUCCESS"
            };
            return actionResponse;
        }

        public ActionResponseVM<bool> convertDelete(string id, Employee? emp)
        {
            var actionResponse = new ActionResponseVM<bool>();

            if (emp == null)
            {
                actionResponse.Data = false;
                actionResponse.Successful = false;
                actionResponse.CodeStatus = 404;
                actionResponse.Message = $"Id: '{id}' not found";
                return actionResponse;
            }
            actionResponse.Data = true;
            actionResponse.Successful = true;
            actionResponse.CodeStatus = 200;
            actionResponse.Message = "SUCCESS";
            return actionResponse;
        }

        public ActionResponseVM<EmployeeGetResponseVM?> ConvertGet(string id, EmployeeGetResponseVM emp)
        {
            var actionResponse = new ActionResponseVM<EmployeeGetResponseVM?>();
            if (emp == null)
            {
                actionResponse.Data = null;
                actionResponse.Successful = false;
                actionResponse.CodeStatus = 404;
                actionResponse.Message = $"Id: '{id}' not found";
                return actionResponse;
                // throw new Exception($"\nLogic: EmployeeLogic: get FAILED. Id: '{id}'");
            }
            actionResponse.Data = emp;
            actionResponse.Successful = true;
            actionResponse.CodeStatus = 200;
            actionResponse.Message = "SUCCESS";
            return actionResponse;
        }
    }
}
