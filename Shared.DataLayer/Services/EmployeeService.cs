using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Shared.DataLayer.Interfaces.IServices;
using Shared.DataLayer.Util;
using Shared.Models.DTO;
using Shared.Models.Helper;
using Shared.Models.Tables;

namespace Shared.DataLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _client;
        private EmployeeDto _employee;

        public EmployeeService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(UrlString.BaseAddress());
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<EmployeeDto> SelectAll()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("/hrdapi/employee/");

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<EmployeeDto>();
            }
            catch (Exception ex)
            {
                _employee = new EmployeeDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = ex.Message
                    }
                };
                return _employee;
            }
        }

        public async Task<EmployeeDto> SelectById(int? id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(string.Format("/hrdapi/employee/" + id));

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<EmployeeDto>();
            }
            catch (Exception ex)
            {
                _employee = new EmployeeDto
                {
                    Status = new Status
                    {
                        Code = "Error",
                        Message = ex.Message
                    }
                };
                return _employee;
            }
        }

        public Task<EmployeeDto> Insert(Employee model)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> Update(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
