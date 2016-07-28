using System.Threading.Tasks;
using System.Web.Http;
using Shared.DataLayer.Interfaces.IRepositories;
using Shared.Models.DTO;
using Shared.Models.Helper;

namespace Shared.Api.Controllers
{
    [RoutePrefix("hrdapi/employee")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeRepository _employeeRepo;
        private EmployeeDto _employee;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        // GET: api/Employee
        [HttpGet]
        [Route("")]
        public async Task<EmployeeDto> GetAllEmployee()
        {
            _employee = new EmployeeDto
            {
                ModelList =  await _employeeRepo.SelectAll(),
                Status = new Status
                {
                    Code = "Success",
                    Message = "Employee"
                }
            };
            return _employee;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeDto> GetEmployee(int? id)
        {
            if (id == null)
            {
                _employee = new EmployeeDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = "Id is not set!"
                    }
                };
                return _employee;
            }

            var model = await _employeeRepo.SelectById(id);

            if (model == null)
            {
                _employee = new EmployeeDto
                {
                    Status = new Status
                    {
                        Code = "Bad Request",
                        Message = "No record found!"
                    }
                };
                return _employee;
            }

            _employee = new EmployeeDto
            {
                ModelSingle = model,
                Status = new Status
                {
                    Code = "Success",
                    Message = "Employee!"
                }
            };
            return _employee;
        } 
    }
}
