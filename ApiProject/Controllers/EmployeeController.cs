using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels.RequestVMs;
using DataAccessLayer.ViewModels.ResponseVMs;
using Logic.Interfaces;
using Logic.ResponseLogics;
using Logic.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeLogic _employeeLogic = new EmployeeLogic();

        [HttpPost("addEmployee")]
        public async Task<ActionResponseVM<string>> Add([FromBody] EmployeeAddRequestVM request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _employeeLogic.add(request);
                    return response;
                }
                throw new Exception($"\nInvalid request model: {request}");
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nApiProject: EmployeeController: Add FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        [HttpPut("updateEmployee")]
        public async Task<ActionResponseVM<bool?>> Update([FromQuery] string id, [FromBody] EmployeeUpdateRequestVM request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _employeeLogic.update(id, request);
                    return response;
                }
                throw new Exception($"\nInvalid request model: {request}");
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nApiProject: EmployeeController: Update FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        [HttpGet("getAllEmployee")]
        public ActionResponseVM<List<EmployeeGetAllResponseVM>> GetAll()
        {
            try
            {
                var response = _employeeLogic.getAll();
                return response;
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nApiProject: EmployeeController: GetAll FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        [HttpDelete("deleteEmployee")]
        public async Task<ActionResponseVM<bool>> Delete([FromQuery] string id)
        {
            try
            {
                var response = await _employeeLogic.delete(id);
                return response;
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nApiProject: EmployeeController: Delete FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }

        [HttpGet("getEmployee")]
        public async Task<ActionResponseVM<EmployeeGetResponseVM?>> Get(string id)
        {
            try
            {
                var response = await _employeeLogic.get(id);
                return response;
            }
            catch (Exception ex)
            {
                var ewsExcption = new Exception($"\nApiProject: EmployeeController: Get FAILED with Message:{ex.Message}\nStackTrace: {ex.StackTrace}\n");
                throw new Exception(ewsExcption.Message);
            }
        }
    }
}
