using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.RequestVMs;
using DataAccessLayer.ViewModels.ResponseVMs;
using Logic.Helpers;
using Logic.Interfaces;
using Logic.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ResponseLogics
{
    public class EmployeeLogic: IEmployeeLogic
    {
        private IEmployeeFunctions _employeeFunctions = new EmployeeFunctions();
        private ILogicHelper _logicHelper = new LogicHelper();
        public async Task<ActionResponseVM<string>> add(EmployeeAddRequestVM requestVM)
        {
            try
            {
                var response = await _employeeFunctions.addEmployee(requestVM);
                var actionResponse = _logicHelper.convertAdd(response);
                return actionResponse;
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nLogic: EmployeeLogic: add FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        public async Task<ActionResponseVM<bool?>> update(string id, EmployeeUpdateRequestVM requestVM)
        {
            try
            {
                var response = await _employeeFunctions.updateEmployee(id, requestVM);
                var actionResponse = _logicHelper.convertUpdate(id, response);
                return actionResponse;
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nLogic: EmployeeLogic: update FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        public ActionResponseVM<List<EmployeeGetAllResponseVM>> getAll()
        {
            try
            {
                var response = _employeeFunctions.getAllEmployee();
                var actionResponse = _logicHelper.convertGetAll(response);
                return actionResponse;
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nLogic: EmployeeLogic: getAll FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        public async Task<ActionResponseVM<bool>> delete(string id)
        {
            try
            {
                var response = await _employeeFunctions.deleteEmployee(id);
                var actionResponse = _logicHelper.convertDelete(id, response);
                return actionResponse;
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nLogic: EmployeeLogic: delete FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        public async Task<ActionResponseVM<EmployeeGetResponseVM?>> get(string id)
        {
            try
            {
                var response = await _employeeFunctions.getEmployee(id);
                var actionResponse = _logicHelper.ConvertGet(id, response);
                return actionResponse;
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nLogic: EmployeeLogic: get FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }
    }
}
